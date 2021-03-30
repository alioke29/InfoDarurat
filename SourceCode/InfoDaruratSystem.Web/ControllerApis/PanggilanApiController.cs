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
    public class PanggilanApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public PanggilanApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<PanggilanEntity.Panggilan>> Gets()
        {

            var PanggilanList = context.Panggilans.ToList();

            return PanggilanList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<PanggilanEntity.Panggilan>> GetsFilter(string nama)
        {

            var PanggilanList = context.Panggilans.ToList();

            if (!string.IsNullOrEmpty(nama))
                PanggilanList = PanggilanList.Where(x => x.Nama.ToLower().Contains(nama.ToLower())).ToList();

            return PanggilanList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<PanggilanEntity.Panggilan> Get(long id)
        {
            var panggilan = context.Panggilans.Find(id);

            if (panggilan == null)
            {
                return NotFound();
            }

            return panggilan;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] PanggilanEntity.Panggilan panggilan)
        {

            context.Entry(panggilan).State = EntityState.Added;
            context.Panggilans.Add(panggilan);
            context.SaveChanges();

            CreatedAtAction(nameof(panggilan), new { id = panggilan.ID }, panggilan);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] PanggilanEntity.Panggilan Panggilan)
        {
            
            if (id != Panggilan.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(Panggilan).State = EntityState.Modified;
            context.Update(Panggilan);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var Panggilan = context.Panggilans.Find(id);

            if (Panggilan == null)
            {
                NotFound();
                return;
            }

            context.Panggilans.Remove(Panggilan);
            context.SaveChanges();
        }

    }
}
