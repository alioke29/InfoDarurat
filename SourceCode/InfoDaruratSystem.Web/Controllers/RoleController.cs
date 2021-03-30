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
    public class RoleController : Controller
    {
        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public RoleEntity.Role roleInfo;
        public RoleController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }
        public IActionResult RoleList()
        {

            return View();
        }

        public IActionResult RoleDetail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEditRole(string id, string paramAll)
        {

            object result = null;

            try
            {
                string[] iParams;
                iParams = paramAll.Split('~');

                string roleName = iParams[0].ToString();

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/RoleApi/GetList").Result;
                var resultRole = JsonConvert.DeserializeObject<List<RoleEntity.Role>>(text);

                int countRoleName = resultRole.Where(x => x.RoleName == roleName.Trim()).Count();

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

                    string roleNameEdit = resultRole.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().RoleName;

                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (roleNameEdit != roleName && countRoleName > 0)
                        result = new { error = 2 };
                    else
                    {
                        // Edit Role
                        roleInfo = new RoleEntity.Role();
                        roleInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(roleInfo);
                        var putTask = client.PutAsync("api/RoleApi/UpdateById=" + id, new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
                        putTask.Wait();

                        result = new { error = "Edit" };
                    }
                }
                else
                {
                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (countRoleName > 0)
                        result = new { error = 2 };
                    else
                    {
                        // Add Role
                        roleInfo = new RoleEntity.Role();
                        roleInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(roleInfo);
                        var putTask = client.PostAsync("api/RoleApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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

        private RoleEntity.Role GetPopulateData(string id, string paramAll)
        {

            string[] iParams;

            iParams = paramAll.Split('~');

            string roleName = iParams[0].ToString();
            string desc = iParams[1].ToString();

            roleInfo = new RoleEntity.Role();

            if (!string.IsNullOrEmpty(id) && id != "0")
                roleInfo.ID = Convert.ToInt16(id);

            roleInfo.RoleName = roleName;
            roleInfo.Desc = desc;

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/RoleApi/GetList").Result;
                var resultRole = JsonConvert.DeserializeObject<List<RoleEntity.Role>>(text);

                roleInfo.CreatedDate = resultRole.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedDate;
                roleInfo.CreatedBy = resultRole.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedBy;
                roleInfo.UpdatedDate = DateTime.Now;
                roleInfo.UpdatedBy = "System"; 
            }
            else
            {
                roleInfo.CreatedDate = DateTime.Now;
                roleInfo.CreatedBy = "System";
                roleInfo.UpdatedDate = null;
                roleInfo.UpdatedBy = null;
            }

            return roleInfo;
        }

        [HttpGet]
        public ActionResult DeleteRole(string id = "")
        {
            int roleId = 0;
            object result = null;


            try
            {
                roleId = Convert.ToInt16(id);

                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/UserApi/GetList").Result;
                var resultUser = JsonConvert.DeserializeObject<List<UserEntity.User>>(text);
                int countUser = resultUser.Where(x => x.IDRole == roleId).Count();

                if (countUser > 0)
                    result = new { error = 1 };
                else
                {

                    var putTask = client.DeleteAsync("api/RoleApi/DeleteById=" + id);
                    putTask.Wait();

                    result = new { error = 0 };
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
