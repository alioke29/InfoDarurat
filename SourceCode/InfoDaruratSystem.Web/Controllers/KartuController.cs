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
    public class KartuController : Controller
    {
        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public KartuEntity.Kartu kartuInfo;

        public KartuController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }
        public IActionResult KartuList()
        {

            return View();
        }

        public IActionResult KartuDetail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEditKartu(string id, string paramAll)
        {

            object result = null;

            try
            {
                string[] iParams;
                iParams = paramAll.Split('~');

                string noKartu = iParams[0].ToString();

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/KartuApi/GetList").Result;
                var resultKartu = JsonConvert.DeserializeObject<List<KartuEntity.Kartu>>(text);

                int countNoKartu = resultKartu.Where(x => x.NoKartu == noKartu.Trim()).Count();

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

                    string noKartuEdit = resultKartu.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().NoKartu;

                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (noKartuEdit != noKartu && countNoKartu > 0)
                        result = new { error = 2 };
                    else
                    {
                        // Edit Kartu
                        kartuInfo = new KartuEntity.Kartu();
                        kartuInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(kartuInfo);
                        var putTask = client.PutAsync("api/KartuApi/UpdateById=" + id, new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
                        putTask.Wait();

                        result = new { error = "Edit" };
                    }
                }
                else
                {
                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (countNoKartu > 0)
                        result = new { error = 2 };
                    else
                    {
                        // Add Kartu
                        kartuInfo = new KartuEntity.Kartu();
                        kartuInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(kartuInfo);
                        var putTask = client.PostAsync("api/KartuApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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

        private KartuEntity.Kartu GetPopulateData(string id, string paramAll)
        {

            string[] iParams;

            iParams = paramAll.Split('~');

            string jenisKartu  = iParams[0].ToString();
            string noKartu = iParams[1].ToString();
            string namaPetugas = iParams[2].ToString();
            string status = iParams[3].ToString();

            kartuInfo = new KartuEntity.Kartu();

            if (!string.IsNullOrEmpty(id) && id != "0")
                kartuInfo.ID = Convert.ToInt16(id);

            kartuInfo.Desc = jenisKartu;
            kartuInfo.NoKartu = noKartu;
            kartuInfo.NamaPetugas = namaPetugas;
            kartuInfo.IsActive = Convert.ToBoolean(status);

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/KartuApi/GetList").Result;
                var resultKartu = JsonConvert.DeserializeObject<List<KartuEntity.Kartu>>(text);

                kartuInfo.CreatedDate = resultKartu.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedDate;
                kartuInfo.CreatedBy = resultKartu.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedBy;
                kartuInfo.UpdatedDate = DateTime.Now;
                kartuInfo.UpdatedBy = "System";
            }
            else
            {
                kartuInfo.CreatedDate = DateTime.Now;
                kartuInfo.CreatedBy = "System";
                kartuInfo.UpdatedDate = null;
                kartuInfo.UpdatedBy = null;
            }

            return kartuInfo;
        }

        [HttpGet]
        public ActionResult DeleteKartu(string id = "")
        {
            int KartuId = 0;
            object result = null;


            try
            {
                KartuId = Convert.ToInt16(id);

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var putTask = client.DeleteAsync("api/KartuApi/DeleteById=" + id);
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
