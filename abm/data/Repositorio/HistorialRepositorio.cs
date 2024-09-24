using abm.App.Models;
using abm.data.Conexion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.data.Repositorio
{
    public class HistorialRepositorio 
    {
        private readonly string _connectionString;

        public HistorialRepositorio()
        {
            _connectionString = Conexion.Conexion.GetConnectionString();
        }


        public List<Registro>BuscarHistorial(DateTime desde, DateTime hasta)
        {
            return null;
        }



        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = (int)reader["Id"],
                            Nombre = (string)reader["Nombre"].ToString(),
                            Password = (string)reader["Password"].ToString(),
                            Tipo = reader["Tipo"].ToString()
                        };
                    }
                }
            }

            return usuario;
        }
        public List<Registro>BuscarPersona(string condicion, DateTime desde, DateTime hasta)
        {
            List<Registro> registros= new List<Registro> ();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sqlQuery = @"
                       select Identificacion,Nombre,Apellido,Departamento,HoraDeIngreso,HoraDeSalida,Motivo from registro r
                        " + (string.IsNullOrEmpty(condicion) ? "" : " AND d.[donde] LIKE @condicion")
                        + "AND r[tiempo_in]>= @fechaDesde"
                        + "AND r[tiempo_in]>= @fechaHasta"
                        ;

                    using (SqlCommand cmd= new SqlCommand(sqlQuery, con))
                    {
                        if (!string.IsNullOrEmpty(condicion))
                        {
                            cmd.Parameters.AddWithValue("@condicion", $"#%{condicion}%");
                        }
                        cmd.Parameters.AddWithValue("@fechaDesde", desde);
                        cmd.Parameters.AddWithValue("@fechaHasta", hasta);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                registros.Add(new Registro 
                                (
                                    reader["Identificacion"].ToString(),
                                    reader["Nombre"].ToString(),
                                    reader["Apellido"].ToString(),
                                    reader["Departamento"].ToString(),
                                    Convert.ToDateTime(reader["HoraDeIngreso"]),
                                    Convert.ToDateTime(reader["HoraDeSalida"]),
                                    reader["Motivo"].ToString()
                                )); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar persona: " + ex.Message);
            }
            return registros;
        }

       //public void btnExportarCsv(object sender, EventArgs args) 
       //{
       //     List<Registro> lineas = new List<Registro>();
       //     lineas.Add(new Registro
       //     {
       //         Identificacion = lineas.["Identificacion"].ToString[],
       //         Nombre= lineas.["Nombre"].ToString[],
       //     });

       //}
    }
}
