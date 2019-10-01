using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=root;database=placemybet";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta a = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetFloat(1) + " " + res.GetBoolean(2) + " " + res.GetFloat(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new Apuesta(res.GetInt32(0), res.GetFloat(1), res.GetBoolean(2), res.GetFloat(3), res.GetDouble(4), res.GetInt32(5), res.GetString(6));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }
    }
}