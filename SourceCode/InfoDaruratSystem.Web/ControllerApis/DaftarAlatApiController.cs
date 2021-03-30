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
    public class DaftarAlatApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public DaftarAlatApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<DaftarAlatEntity.DaftarAlat>> Gets()
        {

            var DaftarAlatList = context.DaftarAlats.ToList();

            return DaftarAlatList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<DaftarAlatEntity.DaftarAlat>> GetsFilter(string namaAlat)
        {

            var DaftarAlatList = context.DaftarAlats.ToList();

            if (!string.IsNullOrEmpty(namaAlat))
                DaftarAlatList = DaftarAlatList.Where(x => x.NamaAlat.ToLower().Contains(namaAlat.ToLower())).ToList();

            return DaftarAlatList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<DaftarAlatEntity.DaftarAlat> Get(long id)
        {
            var daftarAlat = context.DaftarAlats.Find(id);

            if (daftarAlat == null)
            {
                return NotFound();
            }

            return daftarAlat;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] DaftarAlatEntity.DaftarAlat daftarAlat)
        {

            context.Entry(daftarAlat).State = EntityState.Added;
            context.DaftarAlats.Add(daftarAlat);
            context.SaveChanges();

            CreatedAtAction(nameof(daftarAlat), new { id = daftarAlat.ID }, daftarAlat);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] DaftarAlatEntity.DaftarAlat daftarAlat)
        {
            
            if (id != daftarAlat.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(daftarAlat).State = EntityState.Modified;
            context.Update(daftarAlat);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var daftarAlat = context.DaftarAlats.Find(id);

            if (daftarAlat == null)
            {
                NotFound();
                return;
            }

            context.DaftarAlats.Remove(daftarAlat);
            context.SaveChanges();
        }

    }
}
