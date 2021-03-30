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
    public class AktivitasController : Controller
    {
        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public AktivitasEntity.Aktivitas aktivitasInfo;

        public AktivitasController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }
        public IActionResult AktivitasList()
        {

            return View();
        }

        public IActionResult AktivitasDetail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEditAktivitas(string id, string paramAll)
        {

            object result = null;

            try
            {
                string[] iParams;
                iParams = paramAll.Split('~');

                string AktivitasName = iParams[0].ToString();

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/AktivitasApi/GetList").Result;
                var resultAktivitas = JsonConvert.DeserializeObject<List<AktivitasEntity.Aktivitas>>(text);

                //int countAktivitasName = resultAktivitas.Where(x => x.AktivitasName == AktivitasName.Trim()).Count();

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

                    //string AktivitasNameEdit = resultAktivitas.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().AktivitasName;

                    if (isFieldNull)
                        result = new { error = 1 };
                    else
                    {
                        // Edit Aktivitas
                        aktivitasInfo = new AktivitasEntity.Aktivitas();
                        aktivitasInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(aktivitasInfo);
                        var putTask = client.PutAsync("api/AktivitasApi/UpdateById=" + id, new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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
                        // Add Aktivitas
                        aktivitasInfo = new AktivitasEntity.Aktivitas();
                        aktivitasInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(aktivitasInfo);
                        var putTask = client.PostAsync("api/AktivitasApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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

        private AktivitasEntity.Aktivitas GetPopulateData(string id, string paramAll)
        {

            string[] iParams;

            iParams = paramAll.Split('~');

            string kartuId = iParams[0].ToString();
            string jamMasuk = iParams[1].ToString();
            string jamKeluar = iParams[2].ToString();

            aktivitasInfo = new AktivitasEntity.Aktivitas();

            if (!string.IsNullOrEmpty(id) && id != "0")
                aktivitasInfo.ID = Convert.ToInt16(id);

            aktivitasInfo.IDKartu = Convert.ToInt16(kartuId);
            aktivitasInfo.JamMasuk = jamMasuk;
            aktivitasInfo.JamKeluar = jamKeluar;

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/AktivitasApi/GetList").Result;
                var resultAktivitas = JsonConvert.DeserializeObject<List<AktivitasEntity.Aktivitas>>(text);

                aktivitasInfo.CreatedDate = resultAktivitas.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedDate;
                aktivitasInfo.CreatedBy = resultAktivitas.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedBy;
                aktivitasInfo.UpdatedDate = DateTime.Now;
                aktivitasInfo.UpdatedBy = "System"; 
            }
            else
            {
                aktivitasInfo.CreatedDate = DateTime.Now;
                aktivitasInfo.CreatedBy = "System";
                aktivitasInfo.UpdatedDate = null;
                aktivitasInfo.UpdatedBy = null;
            }

            return aktivitasInfo;
        }

        [HttpGet]
        public ActionResult DeleteAktivitas(string id = "")
        {
            int aktivitasId = 0;
            object result = null;


            try
            {
                aktivitasId = Convert.ToInt16(id);

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var putTask = client.DeleteAsync("api/AktivitasApi/DeleteById=" + id);
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
