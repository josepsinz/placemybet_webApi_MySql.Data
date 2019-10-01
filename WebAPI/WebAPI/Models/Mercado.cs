using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Mercado
    {
        public Mercado(int id, float tipoMercado, float cuotaOver, float cuotaUnder, double dineroOver, double dineroUnder, int id_Evento)
        {
            Id = id;
            TipoMercado = tipoMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            Id_Evento = id_Evento;
        }

        public int Id { get; set; }
        public float TipoMercado { get; set; }
        public float CuotaOver { get; set; }
        public float CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int Id_Evento { get; set; }

    }
}