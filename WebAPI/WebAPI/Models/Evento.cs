using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Evento
    {
        public Evento(int id, DateTime fecha, string local, int golesLocal, string visitante, int golesVisitante)
        {
            Id = id;
            Fecha = fecha;
            Local = local;
            GolesLocal = golesLocal;
            Visitante = visitante;
            GolesVisitante = golesVisitante;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Local { get; set; }
        public int GolesLocal { get; set; }
        public string Visitante { get; set; }
        public int GolesVisitante { get; set; }
    }
}