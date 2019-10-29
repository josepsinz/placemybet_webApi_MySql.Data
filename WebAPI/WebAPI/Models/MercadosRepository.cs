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

        internal Mercado Retrieve(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado where Id=@id";
            command.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado m = null;
               
                if (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new Mercado(res.GetInt32(0), res.GetFloat(1), res.GetFloat(2), res.GetFloat(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                }

                con.Close();
                return m;
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2) + " " + res.GetFloat(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new MercadoDTO(res.GetFloat(1), res.GetFloat(2), res.GetFloat(3));
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

        internal List<MercadoDTO> RetrieveDTO(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select mercado.Mercado, mercado.Cuota_Over, mercado.Cuota_Under FROM mercado, evento WHERE evento.Id=mercado.Id_Evento AND evento.Id=@idevento";
            command.Parameters.AddWithValue("@idevento", id);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetFloat(0) + " " + res.GetFloat(1) + " " + res.GetFloat(2));
                    MercadoDTO m = new MercadoDTO(res.GetFloat(0), res.GetFloat(1), res.GetFloat(2));
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

        internal void Refresh(Mercado m, Apuesta a)
        {
            if (a.Tipo)
            {
                m.DineroOver += a.Apostado;
            } else
            {
                m.DineroUnder += a.Apostado;
            }
            
            double probOV = m.DineroOver / (m.DineroOver + m.DineroUnder);
            double cuotaOV = 1 / probOV * 0.95;
            double probUN = m.DineroUnder / (m.DineroOver + m.DineroUnder);
            double cuotaUN = 1 / probUN * 0.95;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "update mercado set Cuota_Over=@ctO, Cuota_Under=@ctU, Dinero_Over=@dO, Dinero_Under=@dU where Id=@id";
            
            command.Parameters.AddWithValue("@ctO", cuotaOV);
            command.Parameters.AddWithValue("@ctU", cuotaUN);
            command.Parameters.AddWithValue("@dO", m.DineroOver);
            command.Parameters.AddWithValue("@dU", m.DineroUnder);
            command.Parameters.AddWithValue("@id", m.Id);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                Debug.WriteLine("Se ha producido un error de conexión");
               
            }
        }
    }
}