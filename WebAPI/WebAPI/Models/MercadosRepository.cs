using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=root;database=placemybet";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new Mercado(res.GetInt32(0), res.GetFloat(1), res.GetFloat(2), res.GetFloat(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                    mercados.Add(m);
                }

                con.Close();
                return mercados;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }
    }
}