using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using InfoDaruratSystem.Web.Models;

using InfoDaruratSystem.Web.Library;
using InfoDaruratSystem.Web.Library.DataAccess;
using InfoDaruratSystem.Web.Library.Utilities;
using InfoDaruratSystem.Web.Library.Entities;

using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text;

namespace InfoDaruratSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext context;
        public IHostingEnvironment hosting;
        public SessionUtility session;
        public HomeController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                              SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        public IActionResult GetLogoutIfSessionNull()
        {


            // Remove Cookies 
            session.SetSession("sesUserName", "");
            session.RemoveSession("sesUserName");

            return Redirect("/Login/Index");
        }

        private object GetMenuList()
        {
            object result = null;

            try
            {

                //session.SetSession("sesUserName", "admin");

                if (session.GetSession("sesUserName") != null)
                {

                    string sesUserName = session.GetSession("sesUserName").ToString();

                    HttpClient client = new HttpClient();

                    string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                    client.BaseAddress = new Uri(baseUrl);

                    var textUser = client.GetStringAsync("api/UserApi/GetList").Result;
                    var resultUser = JsonConvert.DeserializeObject<List<UserEntity.User>>(textUser);

                    var textRole = client.GetStringAsync("api/RoleApi/GetList").Result;
                    var resultRole = JsonConvert.DeserializeObject<List<RoleEntity.Role>>(textRole);

                    string userId = "";
                    string roleId = "";
                    string fullname = "";
                    string roleName = "";


                    userId = resultUser.Where(x => x.UserName.ToLower() == sesUserName.ToLower()).FirstOrDefault().ID.ToString();

                    roleId = resultUser.Where(x => x.UserName.ToLower() == sesUserName.ToLower()).FirstOrDefault().IDRole.ToString();
                    roleName = resultRole.Where(x => x.ID == Convert.ToInt16(roleId)).FirstOrDefault().RoleName;
                    fullname = resultUser.Where(x => x.UserName.ToLower() == sesUserName.ToLower()).FirstOrDefault().Fullname;


                    // Get Name into Header
                    ViewData["vdHeaderName"] = fullname;

                    // Kartu List
                    var textKartu = client.GetStringAsync("api/KartuApi/GetList").Result;
                    var resultKartu = JsonConvert.DeserializeObject<List<KartuEntity.Kartu>>(textKartu);

                    ViewData["vdKartuList"] = resultKartu;


                    // Select Menu By Role Id                  
                    MenuRepository menu = new MenuRepository(context, hosting, session);

                    IEnumerable<MenuEntity.Menu> list = menu.GetListMenuByRole(Convert.ToInt16(roleId));

                    result = list;
                }
                else
                {
                    ViewData["vdHeaderName"] = null;

                    GetLogoutIfSessionNull();

                    result = null;
                }


            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result;
        }

        public IActionResult Index()
        {
           
            return View(GetMenuList());
        }

        public void GetTreviewExpand(long menuId, long subMenuId)
        {
            // Treeview control
            ViewData["vdTreeviewMenuId"] = menuId;
            ViewData["vdTreeviewSubMenuId"] = subMenuId;

            // Set Session
            HttpContext.Session.SetString("sesMenuId", menuId.ToString());
            HttpContext.Session.SetString("sesSubMenuId", subMenuId.ToString());
        }
        public void GetMenuRootInfo(string menuId, string subMenuId)
        {
            // Menu Root Info

            MenuRepository menu = new MenuRepository(context, hosting, session);
            IEnumerable<MenuEntity.Menu> list = menu.GetListMenuByParentAndMenuId(Convert.ToInt16(menuId), Convert.ToInt16(subMenuId));

            ViewData["vdParentName"] = menu.GetListById(Convert.ToInt16(menuId)).FirstOrDefault().DisplayName;
            ViewData["vdDisplayName"] = list.FirstOrDefault().DisplayName;
        }


        // USER Section
        public IActionResult UserList(string id = "", string isFilter = "",
                                      string fullname = "", string email = "", 
                                      string isActive = "", string roleId = "")
        {


            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            if (string.IsNullOrEmpty(isFilter) && string.IsNullOrEmpty(fullname) &&
                string.IsNullOrEmpty(email) && string.IsNullOrEmpty(isActive) &&
                string.IsNullOrEmpty(roleId))
            {

                var text = client.GetStringAsync("api/UserApi/GetList").Result;
                var result = JsonConvert.DeserializeObject<List<UserEntity.User>>(text);

                ViewData["vdUserList"] = result;
            }
            else
            {

                var text = client.GetStringAsync("api/UserApi/GetListByFilter/?fullname=" + fullname + "&email=" + email + "&isActive=" + isActive + "&roleId=" + roleId).Result;
                var result = JsonConvert.DeserializeObject<List<UserEntity.User>>(text);

                ViewData["vdUserList"] = result;

                ViewData["vdFullname"] = fullname;
                ViewData["vdEmail"] = email;
                ViewData["vdStatus"] = isActive;
                ViewData["vdRole"] = roleId;
            }

            // Kartu List
            var textKartu = client.GetStringAsync("api/KartuApi/GetList").Result;
            var resultKartu = JsonConvert.DeserializeObject<List<KartuEntity.Kartu>>(textKartu);
            resultKartu = resultKartu.OrderBy(x => x.NoKartu).ToList();

            ViewData["vdKartuList"] = resultKartu;

            // Role List
            var textRole = client.GetStringAsync("api/RoleApi/GetList").Result;
            var resultRole = JsonConvert.DeserializeObject<List<RoleEntity.Role>>(textRole);
            resultRole = resultRole.OrderBy(x => Convert.ToInt16(x.ID)).ToList();

            ViewData["vdRoleList"] = resultRole;


            // Treeview control
            string menuId = string.Empty;
            string subMenuId = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                string[] paramAll = id.Split('_');
                menuId = paramAll[0].ToString();
                subMenuId = paramAll[1].ToString();
            }
            else
            {
                menuId = HttpContext.Session.GetString("sesMenuId");
                subMenuId = HttpContext.Session.GetString("sesSubMenuId");
            }

            GetTreviewExpand(Convert.ToInt64(menuId), Convert.ToInt64(subMenuId));
            GetMenuRootInfo(menuId, subMenuId);

            return View("User/UserList", GetMenuList());
        }

        // ROLE Section
        public IActionResult RoleList(string id = "", string isFilter = "",
                                      string roleName = "")
        {

            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            if (string.IsNullOrEmpty(isFilter) && string.IsNullOrEmpty(roleName))
            {

                var text = client.GetStringAsync("api/RoleApi/GetList").Result;
                var result = JsonConvert.DeserializeObject<List<RoleEntity.Role>>(text);

                ViewData["vdRoleList"] = result;
            }
            else
            {

                var text = client.GetStringAsync("api/RoleApi/GetListByFilter/?roleName=" + roleName).Result;
                var result = JsonConvert.DeserializeObject<List<RoleEntity.Role>>(text);

                ViewData["vdRoleList"] = result;

                ViewData["vdRoleName"] = roleName;
            }


            // Treeview control
            string menuId = string.Empty;
            string subMenuId = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                string[] paramAll = id.Split('_');
                menuId = paramAll[0].ToString();
                subMenuId = paramAll[1].ToString();
            }
            else
            {
                menuId = HttpContext.Session.GetString("sesMenuId");
                subMenuId = HttpContext.Session.GetString("sesSubMenuId");
            }

            GetTreviewExpand(Convert.ToInt64(menuId), Convert.ToInt64(subMenuId));
            GetMenuRootInfo(menuId, subMenuId);

            return View("Role/RoleList", GetMenuList());
        }

        public IActionResult KartuList(string id = "", string isFilter = "",
                                       string noKartu = "")
        {

            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            if (string.IsNullOrEmpty(isFilter) && string.IsNullOrEmpty(noKartu))
            {

                var text = client.GetStringAsync("api/KartuApi/GetList").Result;
                var result = JsonConvert.DeserializeObject<List<KartuEntity.Kartu>>(text);

                ViewData["vdKartuList"] = result;
            }
            else
            {

                var text = client.GetStringAsync("api/KartuApi/GetListByFilter/?noKartu=" + noKartu).Result;
                var result = JsonConvert.DeserializeObject<List<KartuEntity.Kartu>>(text);

                ViewData["vdKartuList"] = result;

                ViewData["vdNoKartu"] = noKartu;
            }


            // Treeview control
            string menuId = string.Empty;
            string subMenuId = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                string[] paramAll = id.Split('_');
                menuId = paramAll[0].ToString();
                subMenuId = paramAll[1].ToString();
            }
            else
            {
                menuId = HttpContext.Session.GetString("sesMenuId");
                subMenuId = HttpContext.Session.GetString("sesSubMenuId");
            }

            GetTreviewExpand(Convert.ToInt64(menuId), Convert.ToInt64(subMenuId));
            GetMenuRootInfo(menuId, subMenuId);

            return View("Kartu/KartuList", GetMenuList());
        }

        public IActionResult AktivitasList(string id = "", string isFilter = "",
                                           string jamMasuk = "")
        {

            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            if (string.IsNullOrEmpty(isFilter) && string.IsNullOrEmpty(jamMasuk))
            {

                var text = client.GetStringAsync("api/AktivitasApi/GetList").Result;
                var result = JsonConvert.DeserializeObject<List<AktivitasEntity.Aktivitas>>(text);
                result = result.OrderByDescending(x => x.CreatedDate).ToList();
                    
                ViewData["vdAktivitasList"] = result;
            }
            else
            {

                var text = client.GetStringAsync("api/AktivitasApi/GetListByFilter/?jamMasuk=" + jamMasuk).Result;
                var result = JsonConvert.DeserializeObject<List<AktivitasEntity.Aktivitas>>(text);

                ViewData["vdAktivitasList"] = result;

                ViewData["vdJamMasuk"] = jamMasuk;
            }

            // Kartu List
            var textKartu = client.GetStringAsync("api/KartuApi/GetList").Result;
            var resultKartu = JsonConvert.DeserializeObject<List<KartuEntity.Kartu>>(textKartu);

            ViewData["vdKartuList"] = resultKartu;


            // Treeview control
            string menuId = string.Empty;
            string subMenuId = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                string[] paramAll = id.Split('_');
                menuId = paramAll[0].ToString();
                subMenuId = paramAll[1].ToString();
            }
            else
            {
                menuId = HttpContext.Session.GetString("sesMenuId");
                subMenuId = HttpContext.Session.GetString("sesSubMenuId");
            }

            GetTreviewExpand(Convert.ToInt64(menuId), Convert.ToInt64(subMenuId));
            GetMenuRootInfo(menuId, subMenuId);

            return View("Aktivitas/AktivitasList", GetMenuList());
        }

        // Level Section
        public IActionResult LevelList(string id = "", string isFilter = "",
                                        string levelName = "")
        {

            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            if (string.IsNullOrEmpty(isFilter) && string.IsNullOrEmpty(levelName))
            {

                var text = client.GetStringAsync("api/LevelApi/GetList").Result;
                var result = JsonConvert.DeserializeObject<List<LevelEntity.Level>>(text);

                ViewData["vdLevelList"] = result;
            }
            else
            {

                var text = client.GetStringAsync("api/LevelApi/GetListByFilter/?levelName=" + levelName).Result;
                var result = JsonConvert.DeserializeObject<List<LevelEntity.Level>>(text);

                ViewData["vdLevelList"] = result;

                ViewData["vdLevelName"] = levelName;
            }


            // Treeview control
            string menuId = string.Empty;
            string subMenuId = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                string[] paramAll = id.Split('_');
                menuId = paramAll[0].ToString();
                subMenuId = paramAll[1].ToString();
            }
            else
            {
                menuId = HttpContext.Session.GetString("sesMenuId");
                subMenuId = HttpContext.Session.GetString("sesSubMenuId");
            }

            GetTreviewExpand(Convert.ToInt64(menuId), Convert.ToInt64(subMenuId));
            GetMenuRootInfo(menuId, subMenuId);

            return View("Level/LevelList", GetMenuList());
        }

        // Panggilan Section
        public IActionResult PanggilanList(string id = "", string isFilter = "",
                                          string nama = "")
        {

            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            if (string.IsNullOrEmpty(isFilter) && string.IsNullOrEmpty(nama))
            {

                var text = client.GetStringAsync("api/PanggilanApi/GetList").Result;
                var result = JsonConvert.DeserializeObject<List<PanggilanEntity.Panggilan>>(text);
                result = result.OrderByDescending(x => x.CreatedDate).ToList();

                ViewData["vdPanggilanList"] = result;
            }
            else
            {

                var text = client.GetStringAsync("api/PanggilanApi/GetListByFilter/?nama=" + nama).Result;
                var result = JsonConvert.DeserializeObject<List<PanggilanEntity.Panggilan>>(text);

                ViewData["vdPanggilanList"] = result;

                ViewData["vdNama"] = nama;
            }

            // Level List
            var textLevel = client.GetStringAsync("api/LevelApi/GetList").Result;
            var resultLevel = JsonConvert.DeserializeObject<List<LevelEntity.Level>>(textLevel);

            ViewData["vdLevelList"] = resultLevel;


            // Treeview control
            string menuId = string.Empty;
            string subMenuId = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                string[] paramAll = id.Split('_');
                menuId = paramAll[0].ToString();
                subMenuId = paramAll[1].ToString();
            }
            else
            {
                menuId = HttpContext.Session.GetString("sesMenuId");
                subMenuId = HttpContext.Session.GetString("sesSubMenuId");
            }

            GetTreviewExpand(Convert.ToInt64(menuId), Convert.ToInt64(subMenuId));
            GetMenuRootInfo(menuId, subMenuId);

            return View("Panggilan/PanggilanList", GetMenuList());
        }

        // PersiapanAlat Section
        public IActionResult PersiapanAlatList(string id = "", string isFilter = "",
                                               string namaAlat = "")
        {

            HttpClient client = new HttpClient();

            string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
            client.BaseAddress = new Uri(baseUrl);

            if (string.IsNullOrEmpty(isFilter) && string.IsNullOrEmpty(namaAlat))
            {

                var text = client.GetStringAsync("api/PersiapanAlatApi/GetList").Result;
                var result = JsonConvert.DeserializeObject<List<PersiapanAlatEntity.PersiapanAlat>>(text);
                result = result.OrderByDescending(x => x.CreatedDate).ToList();

                ViewData["vdPersiapanAlatList"] = result;
            }
            else
            {

                var text = client.GetStringAsync("api/PersiapanAlatApi/GetListByFilter/?namaAlat=" + namaAlat).Result;
                var result = JsonConvert.DeserializeObject<List<PersiapanAlatEntity.PersiapanAlat>>(text);

                ViewData["vdPersiapanAlatList"] = result;

                ViewData["vdNamaAlat"] = namaAlat;
            }

            // Level List
            var textLevel = client.GetStringAsync("api/LevelApi/GetList").Result;
            var resultLevel = JsonConvert.DeserializeObject<List<LevelEntity.Level>>(textLevel);

            ViewData["vdLevelList"] = resultLevel;

            // Panggilan List
            var textPanggilan = client.GetStringAsync("api/PanggilanApi/GetList").Result;
            var resultPanggilan = JsonConvert.DeserializeObject<List<PanggilanEntity.Panggilan>>(textPanggilan);

            ViewData["vdPanggilanList"] = resultPanggilan;

            // Daftar Alat List
            var textDaftarAlat = client.GetStringAsync("api/DaftarAlatApi/GetList").Result;
            var resultDaftarAlat = JsonConvert.DeserializeObject<List<DaftarAlatEntity.DaftarAlat>>(textDaftarAlat);

            resultDaftarAlat = resultDaftarAlat.OrderBy(x => x.CreatedDate).ToList();

            ViewData["vdDaftarAlatList"] = resultDaftarAlat;

            //List<string> listDaftarAlat = new List<string>();

            //foreach (var item in resultDaftarAlat)
            //{
            //    listDaftarAlat.Add(item.NamaAlat);
            //}

            //ViewData["vdDaftarAlatList"] = string.Join("~", listDaftarAlat.ToArray());

            // Treeview control
            string menuId = string.Empty;
            string subMenuId = string.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                string[] paramAll = id.Split('_');
                menuId = paramAll[0].ToString();
                subMenuId = paramAll[1].ToString();
            }
            else
            {
                menuId = HttpContext.Session.GetString("sesMenuId");
                subMenuId = HttpContext.Session.GetString("sesSubMenuId");
            }

            GetTreviewExpand(Convert.ToInt64(menuId), Convert.ToInt64(subMenuId));
            GetMenuRootInfo(menuId, subMenuId);

            return View("PersiapanAlat/PersiapanAlatList", GetMenuList());
        }

    }
}
