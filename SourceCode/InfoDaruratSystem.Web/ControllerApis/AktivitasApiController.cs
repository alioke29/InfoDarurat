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
    public class AktivitasApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;
        public AktivitasApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                              SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<AktivitasEntity.Aktivitas>> Gets()
        {

            var AktivitasList = context.Aktivitas.ToList();

            return AktivitasList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<AktivitasEntity.Aktivitas>> GetsFilter(string jamMasuk)
        {

            var aktivitasList = context.Aktivitas.ToList();

            if (!string.IsNullOrEmpty(jamMasuk))
                aktivitasList = aktivitasList.Where(x => x.JamMasuk.ToLower().Contains(jamMasuk.ToLower())).ToList();

            return aktivitasList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<AktivitasEntity.Aktivitas> Get(long id)
        {
            var Aktivitas = context.Aktivitas.Find(id);

            if (Aktivitas == null)
            {
                return NotFound();
            }

            return Aktivitas;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] AktivitasEntity.Aktivitas aktivitas)
        {

            context.Entry(aktivitas).State = EntityState.Added;
            context.Aktivitas.Add(aktivitas);
            context.SaveChanges();

            CreatedAtAction(nameof(aktivitas), new { id = aktivitas.ID }, aktivitas);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] AktivitasEntity.Aktivitas aktivitas)
        {
            
            if (id != aktivitas.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(aktivitas).State = EntityState.Modified;
            context.Update(aktivitas);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var aktivitas = context.Aktivitas.Find(id);

            if (aktivitas == null)
            {
                NotFound();
                return;
            }

            context.Aktivitas.Remove(aktivitas);
            context.SaveChanges();
        }

    }
}
