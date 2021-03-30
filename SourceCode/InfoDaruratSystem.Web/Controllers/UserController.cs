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

//using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InfoDaruratSystem.Web.Controllers
{
    public class UserController : Controller
    {
        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public UserEntity.User userInfo;

        public UserController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                              SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }
        public IActionResult UserList()
        {

            return View();
        }

        public IActionResult UserDetail()
        {

            return View();
        }


        [HttpPost]
        public ActionResult GetLogin(string userName, string password)
        {

            object result = null;

            // Select Login By User and Password
            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            var text = client.GetStringAsync("api/UserApi/GetList").Result;
            var resultUser = JsonConvert.DeserializeObject<List<UserEntity.User>>(text);


            try
            {
                if (ModelState.IsValid)
                {
                    string hashPassword = Functions.HashPasswordSha256(password);

                    int countLoginAll = 0;
                    int countLoginActive = 0;
                    int countIsLogin = 0;

                    countLoginAll = resultUser.Where(x => x.UserName.ToLower() == userName.ToLower().Trim() &&
                                x.Password == hashPassword.Trim()).Count();

                    countLoginActive = resultUser.Where(x => x.UserName.ToLower() == userName.ToLower().Trim() &&
                                                        x.Password == hashPassword.Trim() &&
                                                        x.IsActive == true).Count();

                    countIsLogin = resultUser.Where(x => x.UserName.ToLower() == userName.ToLower().Trim() &&
                                                        x.Password == hashPassword.Trim() &&
                                                        x.IsActive == true &&
                                                        x.IsLogin == true).Count();
                    // If password not null
                    if (countLoginAll > 0)
                    {
                        if (countIsLogin == 0)
                        {

                            // If User is active
                            if (countLoginActive > 0)
                            {

                                session.SetSession("sesUserName", userName);
                                session.SetCookies("cookieUserName", userName);


                                string sesUserName = session.GetSession("sesUserName").ToString();

                                result = new { error = 0 };
                            }
                            else
                                result = new { error = 3 };
                        }
                        else
                            result = new { error = 2 };
                    }
                    else
                        result = new { error = 1 };

                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return Json(result);

        }


        [HttpGet]
        public ActionResult GetLogout()
        {

            object result = null;

            // Remove Cookies 
            session.SetSession("sesUserName", "");
            session.RemoveSession("sesUserName");

            result = new { error = 0 };

            return Json(result);
        }

        [HttpPost]
        public ActionResult AddEditUser(string id, string paramAll)
        {

            object result = null;

            try
            {
                string[] iParams;
                iParams = paramAll.Split('~');

                string userName = iParams[0].ToString();
                string password = iParams[1].ToString();
                string confirmPass = iParams[2].ToString();
                string email = iParams[5].ToString();


                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/UserApi/GetList").Result;
                var resultUser = JsonConvert.DeserializeObject<List<UserEntity.User>>(text);

                int countUserName = resultUser.Where(x => x.UserName == userName.Trim()).Count();
                int countEmail = resultUser.Where(x => x.Email == email.Trim()).Count();

                // is valid email
                bool isValidEmail =  Functions.IsValidEmail(email);

                // is valid alpha numeric
                bool isValidAlphaNumeric = Functions.IsAlphaNumeric(password);

                // If data empty
                bool isFieldNull = false;
                for (int x = 1; x < iParams.Count() - 2; x++)
                {
                    // Mandatory Field
                    if (x != 3)
                    {

                        if (string.IsNullOrEmpty(iParams[x].ToString()))
                        {
                            isFieldNull = true;
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(id) && id != "0")
                {

                    string userNameEdit = resultUser.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().UserName;
                    string emailEdit = resultUser.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().Email;

                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (userNameEdit != userName && countUserName > 0)
                        result = new { error = 2 };
                    else if (!isValidAlphaNumeric)
                        result = new { error = 3 };
                    else if (password.Trim() != confirmPass.Trim())
                        result = new { error = 4 };
                    else if (emailEdit != email && countEmail > 0)
                        result = new { error = 5 };
                    else if (!isValidEmail)
                        result = new { error = 6 };
                    else
                    {
                        // Edit User
                        userInfo = new UserEntity.User();
                        userInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(userInfo);
                        var putTask = client.PutAsync("api/UserApi/UpdateById=" + id, new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
                        putTask.Wait();

                        result = new { error = "Edit" };
                    }
                }
                else
                {
                    if (isFieldNull)
                        result = new { error = 1 };
                    else if (countUserName > 0)
                        result = new { error = 2 };
                    else if (!isValidAlphaNumeric)
                        result = new { error = 3 };
                    else if (password.Trim() != confirmPass.Trim())
                        result = new { error = 4 };
                    else if (countEmail > 0)
                        result = new { error = 5 };
                    else if (!isValidEmail)
                        result = new { error = 6 };
                    else
                    {
                        // Add User
                        userInfo = new UserEntity.User();
                        userInfo = GetPopulateData(id, paramAll);

                        var jsonString = JsonConvert.SerializeObject(userInfo);
                        var putTask = client.PostAsync("api/UserApi/CreateNew", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));
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

        private UserEntity.User GetPopulateData(string id, string paramAll)
        {

            string[] iParams;

            iParams = paramAll.Split('~');

            string userName = iParams[0].ToString();
            string password = iParams[1].ToString();
            string confirmPass = iParams[2].ToString();
            string fullname = iParams[3].ToString();
            string noKartuId = iParams[4].ToString();
            string email = iParams[5].ToString();
            string roleId = iParams[6].ToString();
            string isLogin = iParams[7].ToString();
            string isActive = iParams[8].ToString();

            userInfo = new UserEntity.User();

            if (!string.IsNullOrEmpty(id) && id != "0")
                userInfo.ID = Convert.ToInt16(id);

            userInfo.Code = roleId;
            userInfo.UserName = userName;
            userInfo.Password = Functions.HashPasswordSha256(password);
            userInfo.Fullname = fullname;
            userInfo.IDKartu = Convert.ToInt16(noKartuId);
            userInfo.Email = email;
            userInfo.IDRole = Convert.ToInt16(roleId);
            userInfo.IsLogin = Convert.ToBoolean(isLogin);
            userInfo.IsActive = Convert.ToBoolean(isActive);

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var text = client.GetStringAsync("api/UserApi/GetList").Result;
                var resultUser = JsonConvert.DeserializeObject<List<UserEntity.User>>(text);

                userInfo.LastLoginDate = resultUser.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().LastLoginDate;
                userInfo.CreatedDate = resultUser.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedDate;
                userInfo.CreatedBy = resultUser.Where(x => x.ID == Convert.ToInt16(id)).FirstOrDefault().CreatedBy;
                userInfo.UpdatedDate = DateTime.Now;
                userInfo.UpdatedBy = "System"; 
            }
            else
            {
                //userInfo.LastLoginDate = userInfo.LastLoginDate;
                userInfo.CreatedDate = DateTime.Now;
                userInfo.CreatedBy = "System";
                userInfo.UpdatedDate = null;
                userInfo.UpdatedBy = null;
            }

            return userInfo;
        }

        [HttpGet]
        public ActionResult DeleteUser(string id = "")
        {
            int userId = 0;
            object result = null;


            try
            {
                userId = Convert.ToInt16(id);

                userInfo = new UserEntity.User();
                userInfo.ID = userId;

                // User By Id
                HttpClient client = new HttpClient();

                string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                client.BaseAddress = new Uri(baseUrl);

                var putTask = client.DeleteAsync("api/UserApi/DeleteById=" + id);
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
