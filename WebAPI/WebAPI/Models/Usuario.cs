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
        public bool Administrador { get; set; }
        public string Password { get; set; }

        public Usuario(string email, string nombre, string apellidos, int edad, double fondos, bool administrador, string password)
        {
            Email = email;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Fondos = fondos;
            Administrador = administrador;
            Password = password;
        }
    }

    public class UsuarioDTO
    {
        public string Email { get; set; }
        

        public UsuarioDTO(string email)
        {
            Email = email;
           
        }
    }
}