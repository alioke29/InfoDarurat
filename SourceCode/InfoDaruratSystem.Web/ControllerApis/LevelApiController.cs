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
    public class LevelApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public LevelApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<LevelEntity.Level>> Gets()
        {

            var LevelList = context.Levels.ToList();

            return LevelList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<LevelEntity.Level>> GetsFilter(string levelName)
        {

            var LevelList = context.Levels.ToList();

            if (!string.IsNullOrEmpty(levelName))
                LevelList = LevelList.Where(x => x.LevelName.ToLower().Contains(levelName.ToLower())).ToList();

            return LevelList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<LevelEntity.Level> Get(long id)
        {
            var Level = context.Levels.Find(id);

            if (Level == null)
            {
                return NotFound();
            }

            return Level;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] LevelEntity.Level level)
        {

            context.Entry(level).State = EntityState.Added;
            context.Levels.Add(level);
            context.SaveChanges();

            CreatedAtAction(nameof(level), new { id = level.ID }, level);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] LevelEntity.Level level)
        {
            
            if (id != level.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(level).State = EntityState.Modified;
            context.Update(level);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var level = context.Levels.Find(id);

            if (level == null)
            {
                NotFound();
                return;
            }

            context.Levels.Remove(level);
            context.SaveChanges();
        }

    }
}
