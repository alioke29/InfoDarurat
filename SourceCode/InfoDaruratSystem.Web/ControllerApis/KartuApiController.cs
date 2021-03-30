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

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace InfoDaruratSystem.Web.ControllerApis
{
    [Route("api/[controller]")]
    public class KartuApiController : Controller
    {

        public IHostingEnvironment hosting;
        public ApplicationDbContext context;
        public SessionUtility session;

        public KartuApiController(ApplicationDbContext _context, IHostingEnvironment _hosting,
                      SessionUtility _session)
        {
            context = _context;
            hosting = _hosting;
            session = _session;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetList")]
        public ActionResult<List<KartuEntity.Kartu>> Gets()
        {

            var KartuList = context.Kartus.ToList();

            return KartuList;
        }

        // GET: api/<controller>/MultipleIDr
        [HttpGet]
        [Route("GetListByFilter")]
        public ActionResult<List<KartuEntity.Kartu>> GetsFilter(string noKartu)
        {

            var kartuList = context.Kartus.ToList();

            if (!string.IsNullOrEmpty(noKartu))
                kartuList = kartuList.Where(x => x.NoKartu.ToLower().Contains(noKartu.ToLower())).ToList();

            return kartuList;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById={id}")]
        public ActionResult<KartuEntity.Kartu> Get(long id)
        {
            var kartu = context.Kartus.Find(id);

            if (kartu == null)
            {
                return NotFound();
            }

            return kartu;
        }


        // POST api/<controller>
        [HttpPost]
        [Route("CreateNew")]
        public void Post([FromBody] KartuEntity.Kartu kartu)
        {

            context.Entry(kartu).State = EntityState.Added;
            context.Kartus.Add(kartu);
            context.SaveChanges();

            CreatedAtAction(nameof(kartu), new { id = kartu.ID }, kartu);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("UpdateById={id}")]
        public void Put(long id, [FromBody] KartuEntity.Kartu kartu)
        {
            
            if (id != kartu.ID)
            {
                BadRequest();
                return;
            }

            context.Entry(kartu).State = EntityState.Modified;
            context.Update(kartu);
            context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("DeleteById={id}")]
        public void Delete(long id)
        {

            var kartu = context.Kartus.Find(id);

            if (kartu == null)
            {
                NotFound();
                return;
            }

            context.Kartus.Remove(kartu);
            context.SaveChanges();
        }

        // GET kartu api/<controller>/5
        [HttpGet]
        [Route("kartu={key}")]
        public ActionResult<string> GetKartuKey(string key)
        {
            string kartuKey = "";
            string result = "";

            try
            {

                kartuKey = Functions.HashPasswordSha256(kartuKey);


                if (kartuKey == null)
                {
                    return "Cannot be null.";
                }

                var keyJson = JsonConvert.SerializeObject(key);

                using (HttpClient client = new HttpClient())
                {
                    try
                    {

                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        string baseUrl = Url.Action("", "", null, HttpContext.Request.Scheme);
                        client.BaseAddress = new Uri(baseUrl);

                        HttpResponseMessage HttpResponseMessage = client.PostAsync(new Uri(client.BaseAddress.ToString()), new StringContent(keyJson, Encoding.UTF8, "application/json")).Result;
                        result = HttpResponseMessage.StatusCode.ToString();

                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog(ex.Message, hosting);
                    }

                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, hosting);
            }

            return result;
        }


    }
}
