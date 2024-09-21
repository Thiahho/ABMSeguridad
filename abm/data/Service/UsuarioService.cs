using abm.App.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.data.Repositories
{
    public class UsuarioService : IUsuarioService
    {
        private readonly string connectionString;

        public UsuarioService()
        {
            // conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public Usuario BuscarUsuario(string nombre, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM usu WHERE usu = @Nombre AND pass = @Password";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {//esto bloqueado las inyecciones sql
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Password", password);

                    //esto es mil veces mejor que la cosa que nos dio gustavino
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Nombre = reader["usu"].ToString(),
                                Password = reader["pass"].ToString(),
                                Tipo = reader["tipo"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
