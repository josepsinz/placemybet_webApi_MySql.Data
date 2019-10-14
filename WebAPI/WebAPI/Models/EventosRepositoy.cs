using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EventosRepositoy
    {
        
        private MySqlConnection Connect()
        {
            string connString = "server=localhost;user=root;database=placemybet";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from evento";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Evento e = null;
                List<Evento> eventos = new List<Evento>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4) + " " + res.GetInt32(5));
                    e = new Evento(res.GetInt32(0), res.GetDateTime(1), res.GetString(2), res.GetInt32(3), res.GetString(4), res.GetInt32(5));
                    eventos.Add(e);
                }

                con.Close();
                return eventos;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
            
        }

        internal List<EventoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from evento";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4) + " " + res.GetInt32(5));
                    e = new EventoDTO(res.GetString(2), res.GetString(4));
                    eventos.Add(e);
                }

                con.Close();
                return eventos;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }
        /*
        internal void Save(Evento e)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into evento (Id, Fecha, Local, Goles_Local, Visitante, Goles_Visitante) values ('" + e.Id + "','" + e.Fecha + "','" + e.Local + "','" + e.GolesLocal + "','" + e.Visitante + "','" + e.GolesVisitante + "');";
            Debug.WriteLine("command " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            } 
            catch (MySqlException ex)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }
        }
        */

    }
}