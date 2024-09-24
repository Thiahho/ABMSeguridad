using abm.App.Models;
using abm.data.Repositories;
using abm.data.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tutos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace abm
{
    public partial class his_view : Form
    {
        //SqlConnection con;
        string cuit;
        //string conx;
        private readonly IHistorialService _historialService;
        private List<Registro> registros= new List<Registro>(); 
        public his_view()
        {
            InitializeComponent();
            _historialService = new HistorialService();
        }

        //public his_view(string x)
        //{
        //    this.conx = x;
        //    //Volvemos a hacer conexion a la base para consultar, quizas podriamos consultar todo en el login y tener un objeto que haga las consultas en caso de ser necesario
        //    string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";

        //    this.con = new SqlConnection(connectionString);
        //    InitializeComponent();
        //}


        private void btnbBucar_Click(object sender, EventArgs e)

        {
            string condicion= textBox1.Text;
            DateTime fechaDesde = dateTimePickerDesde.Value.Date;
            DateTime fechaHasta = dateTimePickerHasta.Value.Date;

            registros = _historialService.BuscarPersona(condicion, fechaDesde, fechaHasta);

            if (registros != null && registros.Count>0)
            {
                dataGridView1.DataSource= registros;
                dataGridView1.Refresh();
                dataGridView1.Visible = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows= false;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //private void buscar(String condicion)
        //{

        //    SqlConnection con;
        //    string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";
        //    con = new SqlConnection(connectionString);
        //    DateTime desde = dateTimePickerDesde.Value;
        //    DateTime hasta = dateTimePickerHasta.Value;

        //    String desde_str = desde.Year.ToString() + "-" + desde.Month.ToString().PadLeft(2, '0') + "-" + desde.Day.ToString().PadLeft(2, '0');
        //    String hasta_str = hasta.Year.ToString() + "-" + hasta.Month.ToString().PadLeft(2, '0') + "-" + hasta.Day.ToString().PadLeft(2, '0');

        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    adapter.TableMappings.Add("Table", "entra");
        //    string query = "SELECT d.[donde] AS [DEPERTAMENTO],[tiempo_in] AS [HORA DE INGRESO], s.[sal_time] AS [HORA DE SALIDA] ,m.[motivo] AS [MOTIVO] , p.nombre as [NOMBRE] ,p.ape AS [APELLIDO] ,p.dni AS [IDENTIFICACIÓN] FROM [dbo].[entra] e INNER JOIN [dbo].[motivo] m ON m.id = e.id_motivo INNER JOIN [dbo].[per]	p ON p.dni = e.dni INNER JOIN [dbo].[salida] s ON s.id_entra = e.id INNER JOIN [dbo].[donde] d ON d.id = e.id_donde WHERE e.[id] IN (SELECT [id_entra] FROM [dbo].[salida])AND s.[sal_time] BETWEEN '" + desde_str + "' AND '" + hasta_str + "'" + condicion;
        //    adapter.SelectCommand = new SqlCommand(query, con);

        //    DataSet ds = new DataSet("entra");

        //    adapter.Fill(ds);

        //    if (ds.Tables["entra"].Rows.Count == null)
        //    {
        //    }

        //    else
        //    {
        //        dataGridView1.DataSource = ds.Tables["entra"];
        //        dataGridView1.Refresh();
        //        dataGridView1.Visible = true;
        //        dataGridView1.AllowUserToAddRows = false;
        //        dataGridView1.AllowUserToDeleteRows = false;
        //        dataGridView1.ReadOnly = true;
        //    }
        //}


        //private void buscar(object sender, EventArgs e)
        //{
        //    string condicion= textBox.Text;

        //    Registro registro= _
        //}
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}


        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    FilaClick(e);
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs args)
        {
            FilaClick(args);
        }

        private void FilaClick(DataGridViewCellEventArgs args)
        {
            int rowIndex= args.RowIndex;
            if(rowIndex >= 0)
            {
                var celda = dataGridView1.Rows[rowIndex].Cells[0].Value;
                if (celda != null)
                {
                    string fila= celda.ToString();
                    this.cuit=fila;
                    textBox1.Text= fila;    
                }
                else
                {
                    MessageBox.Show("La celda seleccionada esta vacía.");
                }

            }
            else
            {
                MessageBox.Show("Fila no válida.");
            }
        }



        //private void FilaClick(DataGridViewCellEventArgs e)
        //{
        //    int fila = e.RowIndex;
        //    string tfila;

        //    if (fila != -1)
        //    {
        //        if (dataGridView1.Rows[fila].Cells[0].Value == null)
        //        {
        //        }
        //        else
        //        {

        //            tfila = dataGridView1.Rows[fila].Cells[0].Value.ToString();
        //            this.cuit = tfila;
        //            textBox.Text = tfila;

        //        }
        //    }



        //}



      

        private void his_view_Load(object sender, EventArgs args)
        {
            dateTimePickerDesde.Value=DateTime.Now.AddDays(-30);
            dateTimePickerDesde.Value=DateTime.Now;
            btnbBucar_Click(sender, args);
        }


        private void dataGridView1_Paint(object sender, PaintEventArgs args)
        {
            if (dataGridView1.Rows.Count == 0)
                TextRenderer.DrawText(args.Graphics, "No se encontraron registros.",
                dataGridView1.Font, dataGridView1.ClientRectangle,
                dataGridView1.ForeColor, dataGridView1.BackgroundColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        private void dateTimePickerDesde_ValueChanged(object sender, EventArgs e)
        {
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            // Lista para almacenar los registros
            List<Registro> registros = new List<Registro>();

            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)  // Evitar la fila en blanco que a veces aparece al final
                    continue;

                // Obtener los valores del DataGridView y asegurar la conversión adecuada
                string identificacion = row.Cells["Identificacion"].Value.ToString();
                string nombre = row.Cells["Nombre"].Value.ToString();
                string apellido = row.Cells["Apellido"].Value.ToString();
                string departamento = row.Cells["Departamento"].Value.ToString();

                // Convertir los valores de hora si son de tipo DateTime
                DateTime horaDeIngreso = Convert.ToDateTime(row.Cells["HoraDeIngreso"].Value);
                DateTime horaDeSalida = Convert.ToDateTime(row.Cells["HoraDeSalida"].Value);

                string motivo = row.Cells["Motivo"].Value.ToString();

                // Crear un nuevo Registro con los valores del DataGridView
                Registro registro = new Registro(
                    Identificacion: identificacion,
                    Nombre: nombre,
                    Apellido: apellido,
                    Departamento: departamento,
                    HoraDeIngreso: horaDeIngreso,
                    HoraDeSalida: horaDeSalida,
                    Motivo: motivo
                );

                // Agregar el registro a la lista
                registros.Add(registro);
            }

            // Abrir Form1 y pasar los registros
            Form1 form = new Form1(registros);
            form.ShowDialog();
        }

        //private void btnExportar_Click(object sender, EventArgs e)
        //{
        //    List<Registro> registros = new List<Registro>();
        //    foreach(DataGridView row in dataGridView1.Rows)
        //    {
        //        Registro registro = new Registro
        //        {
        //            Identificacion = row.SelectedCells["Identificacion"].Value.ToString(),
        //            Nombre = row.SelectedCells["Nombre"].ToString(),
        //            Apellido = row.SelectedCells["Apellido"].ToString(),
        //            Departamento = row.SelectedCells["Departamento"].ToString(),
        //            HoraDeIngreso = Convert.ToDateTime(row.SelectedCells["HoraDeIngreso"].Value),
        //            HoraDeSalida = Convert.ToDateTime(row.SelectedCells["HoraDeSalida"].Value),
        //            Motivo = row.SelectedCells["Motivo"].Value.ToString()
        //        };
        //        registros.Add(registro);
        //    }
        //    Form1 form = new Form1(registros);
        //    form.ShowDialog();
        //}
    }
}
