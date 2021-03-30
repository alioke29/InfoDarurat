using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using InfoDaruratSystem.Web.Models;

using InfoDaruratSystem.Web.Library;
using InfoDaruratSystem.Web.Library.DataAccess;
using InfoDaruratSystem.Web.Library.Entities;
using InfoDaruratSystem.Web.Library.Utilities;

using Microsoft.EntityFrameworkCore;

using System.Net.Http;
using System.Net.Http.Headers;

namespace InfoDaruratSystem.Web.Controllers
{
    public class LevelController : Controller
    {
        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public LevelEntity.Level LevelInfo;

        public LevelController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }
        public IActionResult LevelList()
        {

            return View();
        }

        public IActionResult LevelDetail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEditLevel(string id, string paramAll)
        {

            object result = null;

            try
            {
                string[] iParams;
                iParams = paramAll.Split('~');

                string LevelName = iParams[0].ToString();

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/LevelApi/GetList").Result;
                var resultLevel = JsonConvert.DeserializeObject<List<LevelEntity.Level>>(text);

                int countLevelName = resultLevel.Where(x => x.LevelName == LevelName.Trim()).Count();

                // If data empty
                bool isFieldNull = false;
                for (int x = 0; x < iParams.Count() ; x++)
                {
                    if (string.IsNullOrEmpty(iParams[x].ToString()))
                    {
                        isFieldNull = true;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(id) && id != "0")
                {

                    string LevelNameEdit = resultLevel.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().LevelName;

                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (LevelNameEdit != LevelName && countLevelName > 0)
                        result = new { error = 2 };
                    else
                    {
                        // Edit Level
                        LevelInfo = new LevelEntity.Level();
                        LevelInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(LevelInfo);
                        var putTask = client.PutAsync("api/LevelApi/UpdateById=" + id, new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
                        putTask.Wait();

                        result = new { error = "Edit" };
                    }
                }
                else
                {
                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (countLevelName > 0)
                        result = new { error = 2 };
                    else
                    {
                        // Add Level
                        LevelInfo = new LevelEntity.Level();
                        LevelInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(LevelInfo);
                        var putTask = client.PostAsync("api/LevelApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
                        putTask.Wait();

                        result = new { error = "Add" };
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return Json(result);
        }

        private LevelEntity.Level GetPopulateData(string id, string paramAll)
        {

            string[] iParams;

            iParams = paramAll.Split('~');

            string levelName = iParams[0].ToString();
            string desc = iParams[1].ToString();

            LevelInfo = new LevelEntity.Level();

            if (!string.IsNullOrEmpty(id) && id != "0")
                LevelInfo.ID = Convert.ToInt16(id);

            LevelInfo.LevelName = levelName;
            LevelInfo.Desc = desc;

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/LevelApi/GetList").Result;
                var resultLevel = JsonConvert.DeserializeObject<List<LevelEntity.Level>>(text);

                LevelInfo.CreatedDate = resultLevel.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedDate;
                LevelInfo.CreatedBy = resultLevel.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedBy;
                LevelInfo.UpdatedDate = DateTime.Now;
                LevelInfo.UpdatedBy = "System"; 
            }
            else
            {
                LevelInfo.CreatedDate = DateTime.Now;
                LevelInfo.CreatedBy = "System";
                LevelInfo.UpdatedDate = null;
                LevelInfo.UpdatedBy = null;
            }

            return LevelInfo;
        }

        [HttpGet]
        public ActionResult DeleteLevel(string id = "")
        {
            int LevelId = 0;
            object result = null;


            try
            {
                LevelId = Convert.ToInt16(id);

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var putTask = client.DeleteAsync("api/LevelApi/DeleteById=" + id);
                putTask.Wait();

                result = new { error = 0 };
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return Json(result);
        }


    }
}
