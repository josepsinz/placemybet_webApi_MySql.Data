using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Apuesta
    {
        public Apuesta(int id, float mercado, bool tipo, float cuota, double apostado, int id_Evento, string email)
        {
            Id = id;
            Mercado = mercado;
            Tipo = tipo;
            Cuota = cuota;
            Apostado = apostado;
            Id_Evento = id_Evento;
            Email = email;
        }

        public int Id { get; set; }
        public float Mercado { get; set; }
        public bool Tipo { get; set; }
        public float Cuota { get; set; }
        public double Apostado { get; set; }
        public int Id_Evento { get; set; }
        public string Email { get; set; }
    }
}