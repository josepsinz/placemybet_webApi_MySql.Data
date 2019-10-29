using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetDouble(4) + " " + res.GetBoolean(5) + " " + res.GetString(6));
                    u = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetDouble(4), res.GetBoolean(5), res.GetString(6));
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


        internal void Save(Usuario u)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into usuario (Email, Nombre, Apellidos, Edad, Fondos, Administrador, Password) values (@ema, @nom, @ape, @eda, @fon, @adm, @pas)";
            command.Parameters.AddWithValue("@ema", u.Email);
            command.Parameters.AddWithValue("@nom", u.Nombre);
            command.Parameters.AddWithValue("@ape", u.Apellidos);
            command.Parameters.AddWithValue("@eda", u.Edad);
            command.Parameters.AddWithValue("@fon", u.Fondos);
            command.Parameters.AddWithValue("@adm", u.Administrador);
            command.Parameters.AddWithValue("@pas", u.Password);

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