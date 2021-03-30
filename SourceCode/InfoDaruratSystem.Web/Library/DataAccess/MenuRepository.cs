using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using InfoDaruratSystem.Web.Models;

using InfoDaruratSystem.Web.Library;
using InfoDaruratSystem.Web.Library.Entities;
using InfoDaruratSystem.Web.Library.Utilities;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace InfoDaruratSystem.Web.Library.DataAccess
{
    public class MenuRepository
    {
        public ApplicationDbContext context;
        public IHostingEnvironment hosting;
        public SessionUtility session;

        public MenuRepository(ApplicationDbContext _context, IHostingEnvironment _hosting,
                             SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        public List<MenuEntity.Menu> GetList()
        {

            List<MenuEntity.Menu> result = null;

            try
            {
                result = (from row in context.Menus
                          select new MenuEntity.Menu
                          {
                              ID = row.ID,
                              DisplayName = row.DisplayName,
                              UrlNav = row.UrlNav,
                              ParentMenuId = (Int64)row.ParentMenuId,
                              SortNumber = row.SortNumber
                          }).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result;
        }

        public List<MenuEntity.Menu> GetParentList()
        {

            List<MenuEntity.Menu> result = null;

            try
            {
                result = (from row in context.Menus
                          where row.ParentMenuId == 0
                          select new MenuEntity.Menu
                          {
                              ParentMenuId = row.ID,
                              DisplayName = row.DisplayName
                          }).Distinct().ToList();

                result = result.Where(x => x.ParentMenuId != 0).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result;
        }

        public IEnumerable<MenuEntity.Menu> GetListById(int id)
        {

            IEnumerable<MenuEntity.Menu> result = null;

            try
            {
                result = (from row in context.Menus
                          where row.ID == id
                          select new MenuEntity.Menu
                          {
                              ID = row.ID,
                              DisplayName = row.DisplayName,
                              UrlNav = row.UrlNav,
                              ParentMenuId = (Int64)row.ParentMenuId,
                              SortNumber = row.SortNumber
                          });
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result;
        }

        public IEnumerable<MenuEntity.Menu> GetListMenuByRole(int roleId)
        {
            IEnumerable<MenuEntity.Menu> result = null;

            try
            {
                result = (from row in context.Menus
                          join b in context.UserRoles on row.ID equals b.IDMenu
                          where b.IsActiveMenu == true &&
                                b.IDRole == roleId
                          select new MenuEntity.Menu
                          {
                              ID = row.ID,
                              DisplayName = row.DisplayName,
                              UrlNav = row.UrlNav,
                              ParentMenuId = (Int64)row.ParentMenuId,
                              SortNumber = row.SortNumber
                          });
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result.ToList();
        }

        public IEnumerable<MenuEntity.Menu> GetListMenuByParentAndMenuId(int menuId, int subMenuId)
        {
            IEnumerable<MenuEntity.Menu> result = null;

            try
            {
                result = (from row in context.Menus
                          where row.ParentMenuId == menuId &&
                                row.ID == subMenuId
                          select new MenuEntity.Menu
                          {
                              ID = row.ID,
                              DisplayName = row.DisplayName,
                              UrlNav = row.UrlNav,
                              ParentMenuId = (Int64)row.ParentMenuId,
                              SortNumber = row.SortNumber
                          });
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result.ToList();
        }
        public List<MenuEntity.Menu> GetListByFilter(string menuName)
        {
            List<MenuEntity.Menu> result = null;

            try
            {
                result = (from row in context.Menus
                          select new MenuEntity.Menu
                          {
                              ID = row.ID,
                              DisplayName = row.DisplayName,
                              UrlNav = row.UrlNav,
                              ParentMenuId = (Int64)row.ParentMenuId,
                              SortNumber = row.SortNumber,
                          }).ToList();

                if (!string.IsNullOrEmpty(menuName))
                    result = result.Where(x => x.DisplayName.ToLower().Contains(menuName.ToLower())).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result;
        }

        public object Add(MenuEntity.Menu menu)
        {

            object result = null;

            try
            {
                result = context.Menus.Add(menu);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public object Update(MenuEntity.Menu menu)
        {

            object result = null;

            try
            {
                result = context.Menus.Update(menu);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public object Delete(int id)
        {

            MenuEntity.Menu menu = new MenuEntity.Menu();
            object result = null;

            try
            {
                menu.ID = id;
                result = context.Menus.Remove(menu);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }


    }
}
