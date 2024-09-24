using abm.App.Models;
using abm.data.Repositorio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abm.data.Repositories
{
    internal class HistorialService : IHistorialService
    {
        private readonly HistorialRepositorio _historialRepositorio;

        public HistorialService()
        {
            _historialRepositorio= new HistorialRepositorio();

        }
        public List<Registro> BuscarPersona(string condicion, DateTime desde, DateTime hasta)
        {
            try
            {
                var historial = _historialRepositorio.BuscarPersona(condicion, desde, hasta);
                return historial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Registro>();

            }


        }

        public void ExportarCsv(List<Registro> registros, string ruta, string separador)
        {
            List<string> lineas = new List<string>();
            string[] columnas = { "Departamento", "HoraDeIngreso", "HoraDeSalida", "Motivo", "Nombre", "Apellido", "Identificacion" };

            // Agrega los encabezados al archivo CSV
            lineas.Add(string.Join(separador, columnas));

            // Recorre la lista de registros y agrega cada uno como una línea al CSV
            foreach (var registro in registros)
            {
                string[] celdas = {
                    registro.Departamento,
                    registro.HoraDeIngreso?.ToString("yyyy-MM-dd HH:mm:ss"),
                    registro.HoraDeSalida?.ToString("yyyy-MM-dd HH:mm:ss"),
                    registro.Motivo,
                    registro.Nombre,
                    registro.Apellido,
                    registro.Identificacion
                };
                lineas.Add(string.Join(separador, celdas));
            }

            // Escribe todas las líneas en el archivo CSV
            File.WriteAllLines(ruta, lineas);
        }

     
    }
}
