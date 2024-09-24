using abm.App.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Usuario usuario = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usu WHERE usu = @Nombre AND pass = @Password",con);

                using (SqlDataReader reader= cmd.ExecuteReader())
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
                }
            }
            return usuario;
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Eror al actualizar el Usuario.", ex.Message);
                return false;
            }
        }
    }

}
