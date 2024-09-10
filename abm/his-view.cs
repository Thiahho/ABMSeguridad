using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tutos;

namespace abm
{
    public partial class his_view : Form
    {
        SqlConnection con;
        string cuit;
        string conx;
        public his_view(string x)
        {
            this.conx = x;

            string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";

            this.con = new SqlConnection(connectionString);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
           
            if (textBox1.Text == "")
            {
                buscar("AND 1=1");
            }
            else
            {
                buscar("AND d.[donde] LIKE '%" + textBox1.Text + "%'");
            }
        }

        private void buscar(String condicion)
        {
           
            SqlConnection con;
            string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";
            con = new SqlConnection(connectionString);
            DateTime desde = dateTimePickerDesde.Value;
            DateTime hasta = dateTimePickerHasta.Value;

            String desde_str = desde.Year.ToString() + "-" + desde.Month.ToString().PadLeft(2, '0') + "-" + desde.Day.ToString().PadLeft(2, '0');
            String hasta_str = hasta.Year.ToString() + "-" + hasta.Month.ToString().PadLeft(2, '0') + "-" + hasta.Day.ToString().PadLeft(2, '0');

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "entra");
            string query = "SELECT d.[donde] AS [DEPERTAMENTO],[tiempo_in] AS [HORA DE INGRESO], s.[sal_time] AS [HORA DE SALIDA] ,m.[motivo] AS [MOTIVO] , p.nombre as [NOMBRE] ,p.ape AS [APELLIDO] ,p.dni AS [IDENTIFICACIÓN] FROM [dbo].[entra] e INNER JOIN [dbo].[motivo] m ON m.id = e.id_motivo INNER JOIN [dbo].[per]	p ON p.dni = e.dni INNER JOIN [dbo].[salida] s ON s.id_entra = e.id INNER JOIN [dbo].[donde] d ON d.id = e.id_donde WHERE e.[id] IN (SELECT [id_entra] FROM [dbo].[salida])AND s.[sal_time] BETWEEN '" + desde_str + "' AND '" + hasta_str + "'" + condicion;
            adapter.SelectCommand = new SqlCommand(query, con);

            DataSet ds = new DataSet("entra");

            adapter.Fill(ds);

            if (ds.Tables["entra"].Rows.Count == null)
            {
            }

            else
            {
                dataGridView1.DataSource = ds.Tables["entra"];
                dataGridView1.Refresh();
                dataGridView1.Visible = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FilaClick(e);
        }

        private void FilaClick(DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            string tfila;

            if (fila != -1)
            {
                if (dataGridView1.Rows[fila].Cells[0].Value == null)
                {
                }
                else
                {

                    tfila = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                    this.cuit = tfila;
                    textBox1.Text = tfila;

                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fio = new Form1(conx);
            fio.ShowDialog();
             

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void his_view_Load(object sender, EventArgs e)
        {
            button1_Click(null, e);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                TextRenderer.DrawText(e.Graphics, "No se encontraron registros.",
                dataGridView1.Font, dataGridView1.ClientRectangle,
                dataGridView1.ForeColor, dataGridView1.BackgroundColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
