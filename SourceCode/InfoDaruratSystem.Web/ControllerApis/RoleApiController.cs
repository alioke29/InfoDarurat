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
    public class RoleApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;
        public RoleApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<RoleEntity.Role>> Gets()
        {

            var roleList = context.Roles.ToList();

            return roleList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<RoleEntity.Role>> GetsFilter(string roleName)
        {

            var roleList = context.Roles.ToList();

            if (!string.IsNullOrEmpty(roleName))
                roleList = roleList.Where(x => x.RoleName.ToLower().Contains(roleName.ToLower())).ToList();

            return roleList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<RoleEntity.Role> Get(long id)
        {
            var role = context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] RoleEntity.Role role)
        {

            context.Entry(role).State = EntityState.Added;
            context.Roles.Add(role);
            context.SaveChanges();

            CreatedAtAction(nameof(role), new { id = role.ID }, role);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] RoleEntity.Role role)
        {
            
            if (id != role.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(role).State = EntityState.Modified;
            context.Update(role);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var role = context.Roles.Find(id);

            if (role == null)
            {
                NotFound();
                return;
            }

            context.Roles.Remove(role);
            context.SaveChanges();
        }

    }
}
