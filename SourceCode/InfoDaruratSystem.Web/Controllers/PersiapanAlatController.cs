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
    public class PersiapanAlatController : Controller
    {
        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public PersiapanAlatEntity.PersiapanAlat persiapanAlatInfo;

        public PersiapanAlatController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }
        public IActionResult PersiapanAlatList()
        {

            return View();
        }

        public IActionResult PersiapanAlatDetail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEditPersiapanAlat(string id, string paramAll, string paramNamaAlat)
        {

            object result = null;

            try
            {

                string panggilanId = paramAll;

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/PersiapanAlatApi/GetList").Result;
                var resultPersiapanAlat = JsonConvert.DeserializeObject<List<PersiapanAlatEntity.PersiapanAlat>>(text);


                // If data empty
                bool isFieldNull = false;

                if (string.IsNullOrEmpty(panggilanId))
                    isFieldNull = true;


                if (!string.IsNullOrEmpty(id) && id != "0")
                {

                    if (isFieldNull)
                        result = new { error = 1 };
                    else
                    {
                        // Edit PersiapanAlat
                        persiapanAlatInfo = new PersiapanAlatEntity.PersiapanAlat();
                        persiapanAlatInfo = GetPopulateData(id, paramAll, paramNamaAlat);

                        var jsonString = JsonConvert.SerializeObject(persiapanAlatInfo);
                        var putTask = client.PutAsync("api/PersiapanAlatApi/UpdateById=" + id, new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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
                        // Add PersiapanAlat
                        persiapanAlatInfo = new PersiapanAlatEntity.PersiapanAlat();
                        persiapanAlatInfo = GetPopulateData(id, paramAll, paramNamaAlat);

                        var jsonString = JsonConvert.SerializeObject(persiapanAlatInfo);
                        var putTask = client.PostAsync("api/PersiapanAlatApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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

        private PersiapanAlatEntity.PersiapanAlat GetPopulateData(string id, string paramAll,
                                                                  string paramNamaAlat)
        {

            string[] iParams;

            string panggilanId = paramAll;
            
            persiapanAlatInfo = new PersiapanAlatEntity.PersiapanAlat();

            if (!string.IsNullOrEmpty(id) && id != "0")
                persiapanAlatInfo.ID = Convert.ToInt16(id);

            persiapanAlatInfo.IDPanggilan = Convert.ToInt16(panggilanId);
            persiapanAlatInfo.NamaPeralatan = paramNamaAlat.Replace("~", ", ");

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/PersiapanAlatApi/GetList").Result;
                var resultPersiapanAlat = JsonConvert.DeserializeObject<List<PersiapanAlatEntity.PersiapanAlat>>(text);

                persiapanAlatInfo.CreatedDate = resultPersiapanAlat.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedDate;
                persiapanAlatInfo.CreatedBy = resultPersiapanAlat.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedBy;
                persiapanAlatInfo.UpdatedDate = DateTime.Now;
                persiapanAlatInfo.UpdatedBy = "System"; 
            }
            else
            {
                persiapanAlatInfo.CreatedDate = DateTime.Now;
                persiapanAlatInfo.CreatedBy = "System";
                persiapanAlatInfo.UpdatedDate = null;
                persiapanAlatInfo.UpdatedBy = null;
            }

            return persiapanAlatInfo;
        }

        [HttpGet]
        public ActionResult DeletePersiapanAlat(string id = "")
        {
            int PersiapanAlatId = 0;
            object result = null;

            try
            {
                PersiapanAlatId = Convert.ToInt16(id);

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var putTask = client.DeleteAsync("api/PersiapanAlatApi/DeleteById=" + id);
                putTask.Wait();

                result = new { error = 0 };
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return Json(result);
        }

        [HttpPost]
        public ActionResult AddDaftarAlat(string paramAll)
        {

            object result = null;

            try
            {
                if (paramAll == null)
                    paramAll = "";

                string namaAlat = paramAll;

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/DaftarAlatApi/GetList").Result;
                var resultDaftarAlat = JsonConvert.DeserializeObject<List<DaftarAlatEntity.DaftarAlat>>(text);

                int countNamaAlat = resultDaftarAlat.Where(x => x.NamaAlat == namaAlat.Trim()).Count();

                if (string.IsNullOrEmpty(namaAlat))
                    result = new { error = "1" };
                else if (countNamaAlat > 0)
                    result = new { error = "2" };
                else
                {
                    // Add PersiapanAlat
                    DaftarAlatEntity.DaftarAlat daftarAlatInfo = new DaftarAlatEntity.DaftarAlat();

                    daftarAlatInfo.NamaAlat = namaAlat;
                    daftarAlatInfo.Desc = "";
                    daftarAlatInfo.CreatedDate = DateTime.Now;
                    daftarAlatInfo.CreatedBy = "System";
                    daftarAlatInfo.UpdatedDate = null;
                    daftarAlatInfo.UpdatedBy = null;

                    var jsonString = JsonConvert.SerializeObject(daftarAlatInfo);
                    var putTask = client.PostAsync("api/DaftarAlatApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
                    putTask.Wait();

                    result = new { error = "0" };
                }

            }            
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return Json(result);
        }

    }
}
