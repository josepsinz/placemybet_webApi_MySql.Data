using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UsuariosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=root;database=placemybet";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Usuario> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuario";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Usuario u = null;
                List<Usuario> usuarios = new List<Usuario>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetDouble(4));
                    u = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetDouble(4));
                    usuarios.Add(u);
                }

                con.Close();
                return usuarios;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }
    }
}