using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestasRepository();
            List<Apuesta> apuestas = repo.Retrieve();
            return apuestas;
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuestas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
