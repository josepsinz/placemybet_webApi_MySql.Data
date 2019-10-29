using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();
            return mercados;
        }

        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
            var repo = new MercadosRepository();
            Mercado m = repo.Retrieve(id);
            return m;
        }

        // GET: api/Mercados?id_partido={id_partido}
        public List<MercadoDTO> GetbyEvento(int id_partido)
        {
            var repo = new MercadosRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO(id_partido);
            return mercados;
        }

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
