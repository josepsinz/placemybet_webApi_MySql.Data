using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetFloat(1) + " " + res.GetBoolean(2) + " " + res.GetFloat(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new ApuestaDTO(res.GetFloat(1), res.GetBoolean(2), res.GetFloat(3), res.GetDouble(4), res.GetString(6));
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

        internal List<ApuestaDTO> RetrieveDTO(int id_mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuesta.Mercado, apuesta.Tipo, apuesta.Cuota, apuesta.Apostado, apuesta.Email FROM apuesta, mercado WHERE apuesta.Id_Mercado=mercado.Id AND mercado.Id=@id";
            command.Parameters.AddWithValue("@id", id_mercado);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    //Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetFloat(1) + " " + res.GetBoolean(2) + " " + res.GetFloat(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new ApuestaDTO(res.GetFloat(0), res.GetBoolean(1), res.GetFloat(2), res.GetDouble(3), res.GetString(4));
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

        internal List<ApuestaDTObyEmail> RetrieveDTO(string email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select evento.Id, evento.Fecha, evento.Local, evento.Visitante, apuesta.Mercado, apuesta.Tipo, apuesta.Cuota, apuesta.Apostado from apuesta, usuario, mercado, evento WHERE usuario.Email=apuesta.Email and apuesta.Id_Mercado=mercado.Id and mercado.Id_Evento = evento.Id and usuario.Email=@email";
            command.Parameters.AddWithValue("@email", email);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTObyEmail a = null;
                List<ApuestaDTObyEmail> apuestas = new List<ApuestaDTObyEmail>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetFloat(4) + " " + res.GetBoolean(5) + " " + res.GetFloat(6) + " " + res.GetDouble(7));
                    a = new ApuestaDTObyEmail(res.GetInt32(0), res.GetDateTime(1), res.GetString(2), res.GetString(3), res.GetFloat(4), res.GetBoolean(5), res.GetFloat(6), res.GetDouble(7));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            } catch{
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal void Save(Apuesta a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into apuesta (Mercado, Tipo, Cuota, Apostado, Id_Mercado, Email) values (@mer,@tip,@cuo,@apo,@idm,@ema)";
            command.Parameters.AddWithValue("@mer", a.Mercado);
            command.Parameters.AddWithValue("@tip", a.Tipo);
            command.Parameters.AddWithValue("@cuo", a.Cuota);
            command.Parameters.AddWithValue("@apo", a.Apostado);
            command.Parameters.AddWithValue("@idm", a.Id_Mercado);
            command.Parameters.AddWithValue("@ema", a.Email);

            Debug.WriteLine("command " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }
        }

    }
}

