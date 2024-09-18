using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;
using System.Drawing.Design;
using abm.App.Models;
using System.Runtime.InteropServices;
using abm.data.Repositories;


namespace tutos
{
    public partial class Form1 : Form
    {
        private List<Registro> _registro;
        private readonly IHistorialService _historialService;

        public Form1(List<Registro> registros)
        {
            InitializeComponent();
            this._registro = registros;
        }
 
        //private void btnguardar_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection("Data Source = '" + conx + "'; Initial Catalog = abm; Integrated Security = True");
        //    try
        //    {
        //        con.Open();
        //        DateTime desde = dateTimePickerDesde.Value;
        //        DateTime hasta = dateTimePickerHasta.Value;

        //        String desde_str = desde.Year.ToString() + "-" + desde.Month.ToString().PadLeft(2, '0') + "-" + desde.Day.ToString().PadLeft(2, '0');
        //        String hasta_str = hasta.Year.ToString() + "-" + hasta.Month.ToString().PadLeft(2, '0') + "-" + hasta.Day.ToString().PadLeft(2, '0');

        //        string query = "SELECT [dni],[tiempo_in] AS [Hora], m.[motivo], d.[donde], s.[sal_time] AS [Salida]   FROM [dbo].[entra] e INNER JOIN [dbo].[motivo] m ON m.id = e.id_motivo INNER JOIN [dbo].[salida] s ON s.id_entra = e.id INNER JOIN [dbo].[donde] d ON d.id = e.id_donde WHERE e.[id] IN (SELECT [id_entra] FROM [dbo].[salida]) AND s.[sal_time] BETWEEN '" + desde_str + "' AND '" + hasta_str + "'";
        //        SqlDataAdapter adap = new SqlDataAdapter(query, con);
        //        DataTable tabla = new DataTable();
        //        adap.Fill(tabla);

        //        List<string> lineas = new List<string>(), columnas = new List<string>();
        //        foreach (DataColumn col in tabla.Columns) columnas.Add(col.ColumnName);

        //        lineas.Add(string.Join(txtsep.Text, columnas));
        //        foreach (DataRow fila in tabla.Rows)
        //        {
        //            List<string> celdas = new List<string>();
        //            foreach (object celda in fila.ItemArray) celdas.Add(celda.ToString());

        //            lineas.Add(string.Join(txtsep.Text, celdas));
        //        }
        //        File.WriteAllLines(txtruta.Text, lineas);

        //        con.Close();
        //        MessageBox.Show("OKEY!");
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

      
        //private void ExportCsv(List<Registro> registros, string ruta)
        //{
        //    List<Registro> lineas = new List<Registro>();
        //    string[] columnas = { "Identificacion", "Nombre", "Apellido", "Departamento", "HoraDeIngreso", "HordaDeSalida", "Motivo" };
        //    lineas.Add(string.Join(",", columnas));
        //    foreach (var registro in registros)
        //    {
        //        string[] celdas =
        //        {
        //            registro.Identificacion,
        //            registro.Nombre,
        //            registro.Apellido,
        //            registro.Departamento,
        //            registro.HoraDeIngreso?.ToString("yyyy-MM-dd HH:mm:ss"),
        //            registro.HoraDeSalida?.ToString("yyyy-MM-dd HH:mm:ss"),
        //            registro.Motivo,
        //        };
        //        lineas.Add(string.Join(",", celdas));
        //    }

        //    File.WriteAllLines(ruta, lineas);
        //    MessageBox.Show("Archivo Csv generado!");
        //}

       
            private void btnguardar_Click(object sender, EventArgs args)
            {
                //var registros = _historialService.BuscarPersona();

            }

            private void btnabrir_Click_1(object sender, EventArgs e)
            {
                //SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
                //if (sfd.ShowDialog() == DialogResult.OK) txtruta.Text = sfd.FileName;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Csv File (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string ruta = saveFile.FileName;
                    ExportarCsv(_registro, ruta);
                }
            }
            private void btnSeleccionarRuta_Click(object sender, EventArgs e)
            {
                // Aquí puedes usar un SaveFileDialog para seleccionar la ruta de guardado
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ruta = saveFileDialog.FileName;
                    ExportarCsv(_registro, ruta);  // Llamar al método que exporta los registros
                }
            }

            private void ExportarCsv(List<Registro> registros, string ruta)
            {
                List<string> lineas = new List<string>();
                string[] columnas = { "Departamento", "HoraDeIngreso", "HoraDeSalida", "Motivo", "Nombre", "Apellido", "Identificacion" };
                lineas.Add(string.Join(",", columnas));

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
                    lineas.Add(string.Join(",", celdas));
                }

                File.WriteAllLines(ruta, lineas);
                MessageBox.Show("Archivo CSV guardado correctamente.");
            }



        private void btnverarchivo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtruta.Text);
        }

        private void txtsep_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtruta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}