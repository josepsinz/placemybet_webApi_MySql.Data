using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();
            return apuestas;
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            var repo2 = new MercadosRepository();
            var repo3 = new UsuariosRepository();

            Mercado m = repo2.Retrieve(apuesta.Id_Mercado);
            List<Usuario> users = repo3.Retrieve();
            List<string> emails = new List<string>();
            
            foreach(Usuario u in users)
            {
                emails.Add(u.Email);
            }

            //comprobamos que el cliente existe (email), y que el mercado al que quiere apostar existe (Id_Mercado)
            //solo necesitamos recoger desde la aplicación: el tipo(over/under), el mercado(id_mercado), la cantidad apostada(apostado) y el email del usuario
            //la cuota y el mercado (1.5,2.5...) de al apuesta los recoge del Mercado al que se apuesta, y su Id se genera solo
            if (emails.Contains(apuesta.Email))
            {
                try
                {
                    if (apuesta.Tipo)
                    {
                        apuesta.Cuota = m.CuotaOver;
                    }
                    else
                    {
                        apuesta.Cuota = m.CuotaUnder;
                    }
                    apuesta.Mercado = m.TipoMercado;

                    repo.Save(apuesta);
                    repo2.Refresh(m, apuesta);
                }
                catch
                {
                    Debug.WriteLine("Id_Mercado no existe");
                }
            }
            else
            {
                Debug.WriteLine("Usuario no existe");
            }
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
