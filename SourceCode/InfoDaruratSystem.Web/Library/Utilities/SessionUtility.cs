using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace InfoDaruratSystem.Web.Library.Utilities
{
    public class SessionUtility
    {

        public IHttpContextAccessor httpContextAccessor;

        public SessionUtility(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public void SetSession(string key, string value)
        {
            httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public string GetSession(string key)
        {
            return httpContextAccessor.HttpContext.Session.GetString(key);
        }
        public void RemoveSession(string key)
        {
            httpContextAccessor.HttpContext.Session.Remove(key);
        }

        public void SetCookies(string key, string value)
        {
            CookieOptions cookieOpt = new CookieOptions();

            httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, cookieOpt);
        }

        public string GetCookies(string key)
        {


             return httpContextAccessor.HttpContext.Request.Cookies[key].ToString();
        }

        public void DeleteCookies(string key)
        {
            httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        public string GetRequestParam(string key)
        {
            return httpContextAccessor.HttpContext.Request.Form[key];
        }

    }
}
