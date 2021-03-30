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
    public class PersiapanAlatApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public PersiapanAlatApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                       SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<PersiapanAlatEntity.PersiapanAlat>> Gets()
        {

            var PersiapanAlatList = context.PersiapanAlats.ToList();

            return PersiapanAlatList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<PersiapanAlatEntity.PersiapanAlat>> GetsFilter(string namaAlat)
        {

            var persiapanAlatList = context.PersiapanAlats.ToList();

            if (!string.IsNullOrEmpty(namaAlat))
                persiapanAlatList = persiapanAlatList.Where(x => x.NamaPeralatan.ToLower().Contains(namaAlat.ToLower())).ToList();

            return persiapanAlatList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<PersiapanAlatEntity.PersiapanAlat> Get(long id)
        {
            var persiapanAlat = context.PersiapanAlats.Find(id);

            if (persiapanAlat == null)
            {
                return NotFound();
            }

            return persiapanAlat;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] PersiapanAlatEntity.PersiapanAlat persiapanAlat)
        {

            context.Entry(persiapanAlat).State = EntityState.Added;
            context.PersiapanAlats.Add(persiapanAlat);
            context.SaveChanges();

            CreatedAtAction(nameof(persiapanAlat), new { id = persiapanAlat.ID }, persiapanAlat);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] PersiapanAlatEntity.PersiapanAlat persiapanAlat)
        {
            
            if (id != persiapanAlat.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(persiapanAlat).State = EntityState.Modified;
            context.Update(persiapanAlat);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var PersiapanAlat = context.PersiapanAlats.Find(id);

            if (PersiapanAlat == null)
            {
                NotFound();
                return;
            }

            context.PersiapanAlats.Remove(PersiapanAlat);
            context.SaveChanges();
        }

    }
}
