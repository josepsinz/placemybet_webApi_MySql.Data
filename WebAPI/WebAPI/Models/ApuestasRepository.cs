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
                    a = new ApuestaDTO(res.GetFloat(1), res.GetBoolean(1), res.GetFloat(3), res.GetDouble(4), res.GetString(6));
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

