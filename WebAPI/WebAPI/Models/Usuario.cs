using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Usuario
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public double Fondos { get; set; }

        public Usuario(string email, string nombre, string apellidos, int edad, double fondos)
        {
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Fondos = fondos;
        }
    }
}