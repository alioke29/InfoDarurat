using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using InfoDaruratSystem.Web.Models;
using InfoDaruratSystem.Web.Library;
using InfoDaruratSystem.Web.Library.DataAccess;
using InfoDaruratSystem.Web.Library.Utilities;
using InfoDaruratSystem.Web.Library.Entities;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace InfoDaruratSystem.Web.ControllerApis
{
    [Route("api/[controller]")]
    public class UserApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public UserApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                        SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<UserEntity.User>> Gets()
        {

            var userList = context.Users.ToList();

            return userList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<UserEntity.User>> GetsFilter(string fullname, string email, 
                                                             string isActive, string roleId)
        {

            var userList = context.Users.ToList();

            if (!string.IsNullOrEmpty(fullname))
                userList = userList.Where(x => x.Fullname.ToLower().Contains(fullname.ToLower())).ToList();

            if (!string.IsNullOrEmpty(email))
                userList = userList.Where(x => x.Email.ToLower().Contains(email.ToLower())).ToList();

            if (!string.IsNullOrEmpty(isActive))
                userList = userList.Where(x => x.IsActive == Convert.ToBoolean(isActive)).ToList();

            if (!string.IsNullOrEmpty(roleId))
                userList = userList.Where(x => x.IDRole == Convert.ToInt16(roleId)).ToList();


            return userList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<UserEntity.User> Get(long id)
        {
            var user = context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] UserEntity.User user)
        {

            context.Entry(user).State = EntityState.Added;
            context.Users.Add(user);
            context.SaveChanges();

            CreatedAtAction(nameof(user), new { id = user.ID }, user);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] UserEntity.User user)
        {
            
            if (id != user.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(user).State = EntityState.Modified;
            context.Update(user);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var user = context.Users.Find(id);

            if (user == null)
            {
                NotFound();
                return;
            }

            context.Users.Remove(user);
            context.SaveChanges();
        }

    }
}
