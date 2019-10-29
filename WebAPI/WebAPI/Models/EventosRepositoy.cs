using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
                int goleslocal = -1;
                int golesvisitante = -1;
                List<Evento> eventos = new List<Evento>();
                while (res.Read())
                {
                    if( !res.IsDBNull(3) && !res.IsDBNull(5))
                    {
                        goleslocal = res.GetInt32(3);
                        golesvisitante = res.GetInt32(5);
                    }
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + goleslocal + " " + res.GetString(4) + " " + golesvisitante);
                    e = new Evento(res.GetInt32(0), res.GetDateTime(1), res.GetString(2), goleslocal, res.GetString(4), golesvisitante);
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
                int goleslocal = -1;
                int golesvisitante = -1;
                while (res.Read())
                {
                    
                    if (!res.IsDBNull(3) && !res.IsDBNull(5))
                    {
                        goleslocal = res.GetInt32(3);
                        golesvisitante = res.GetInt32(5);
                    }
                    
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + goleslocal.ToString() + " " + res.GetString(4) + " " + golesvisitante.ToString());
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

        


    }
}