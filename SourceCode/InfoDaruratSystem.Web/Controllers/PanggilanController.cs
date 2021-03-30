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
    public class PanggilanController : Controller
    {
        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public PanggilanEntity.Panggilan panggilanInfo;
        public PanggilanController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                              SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }
        public IActionResult PanggilanList()
        {

            return View();
        }

        public IActionResult PanggilanDetail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEditPanggilan(string id, string paramAll)
        {

            object result = null;

            try
            {
                string[] iParams;
                iParams = paramAll.Split('~');

                string PanggilanName = iParams[0].ToString();

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/PanggilanApi/GetList").Result;
                var resultPanggilan = JsonConvert.DeserializeObject<List<PanggilanEntity.Panggilan>>(text);


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


                    if (isFieldNull)
                        result = new { error = 1 };
                    else
                    {
                        // Edit Panggilan
                        panggilanInfo = new PanggilanEntity.Panggilan();
                        panggilanInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(panggilanInfo);
                        var putTask = client.PutAsync("api/PanggilanApi/UpdateById=" + id, new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
                        putTask.Wait();

                        result = new { error = "Edit" };
                    }
                }
                else
                {
                    if (isFieldNull)
                        result = new { error = 1 };
                    else
                    {
                        // Add Panggilan
                        panggilanInfo = new PanggilanEntity.Panggilan();
                        panggilanInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(panggilanInfo);
                        var putTask = client.PostAsync("api/PanggilanApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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

        private PanggilanEntity.Panggilan GetPopulateData(string id, string paramAll)
        {

            string[] iParams;

            iParams = paramAll.Split('~');

            string levelId = iParams[0].ToString();
            string nama = iParams[1].ToString();
            string spec = iParams[2].ToString();
            string noPanggilan = iParams[3].ToString();

            panggilanInfo = new PanggilanEntity.Panggilan();

            if (!string.IsNullOrEmpty(id) && id != "0")
                panggilanInfo.ID = Convert.ToInt16(id);

            panggilanInfo.IDLevel = Convert.ToInt16(levelId);
            panggilanInfo.Nama = nama;
            panggilanInfo.Spec = spec;
            panggilanInfo.NoPanggilan = noPanggilan;

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/PanggilanApi/GetList").Result;
                var resultPanggilan = JsonConvert.DeserializeObject<List<PanggilanEntity.Panggilan>>(text);

                panggilanInfo.CreatedDate = resultPanggilan.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedDate;
                panggilanInfo.CreatedBy = resultPanggilan.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedBy;
                panggilanInfo.UpdatedDate = DateTime.Now;
                panggilanInfo.UpdatedBy = "System"; 
            }
            else
            {
                panggilanInfo.CreatedDate = DateTime.Now;
                panggilanInfo.CreatedBy = "System";
                panggilanInfo.UpdatedDate = null;
                panggilanInfo.UpdatedBy = null;
            }

            return panggilanInfo;
        }

        [HttpGet]
        public ActionResult DeletePanggilan(string id = "")
        {
            int panggilanId = 0;
            object result = null;

            try
            {
                panggilanId = Convert.ToInt16(id);

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var putTask = client.DeleteAsync("api/PanggilanApi/DeleteById=" + id);
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
