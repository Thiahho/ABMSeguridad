using abm.App.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.data.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio()
        {
            _connectionString = Conexion.Conexion.GetConnectionString();

        }
        public Usuario BuscarUsuario(string nombre, string password)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
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
        public Usuario ObtenerUsuarioPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usu WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Password = reader.GetString(2),
                            Tipo = reader.GetString(3)
                        };
                    }
                }
            }

            return null;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE usu SET Nombre = @Nombre, Password = @Password, Tipo = @Tipo WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
                cmd.Parameters.AddWithValue("@Tipo", usuario.Tipo);
                cmd.Parameters.AddWithValue("@Id", usuario.Id);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }

}
