using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abm
{
    public partial class ING : Form
    {
        SqlConnection con;
        string cuit;
        string conx;

        private Dictionary<string, int> dicMotivos = new Dictionary<string, int>();
        private Dictionary<string, int> dicDonde = new Dictionary<string, int>();

        public ING(string x)
        {
            this.conx = x;
            string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";

            this.con = new SqlConnection(connectionString);
            InitializeComponent();
        }
      

        private void buscar(String condicion)
        {
            SqlConnection con;
            string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";
            con = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "per");
            string query = "SELECT dni AS IDENTIFICACIÓN,  nombre AS NOMBRE,  ape AS Apellido, foto FROM[abm].[dbo].[per] WHERE 1 = 1" + condicion;
            adapter.SelectCommand = new SqlCommand(query, con);

            DataSet ds = new DataSet("per");

            adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables["per"];
                dataGridView1.Refresh();
                
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                TextRenderer.DrawText(e.Graphics, "No se encontraron ",
                dataGridView1.Font, dataGridView1.ClientRectangle,
                dataGridView1.ForeColor, dataGridView1.BackgroundColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FilaClick(e);
        }

        private void FilaClick(DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            string tfila;
            byte[] imagenBytes;

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
                    if (dataGridView1.Rows[fila].Cells[3].Value is System.DBNull)
                    {
                        pictureBox1.Image = Properties.Resources._2;
                    }

                    else
                    {
                        imagenBytes = (byte[])dataGridView1.Rows[fila].Cells[3].Value;
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            Image imagen = Image.FromStream(ms);

                            // Asignar la imagen al PictureBox para mostrarla
                            pictureBox1.Image = imagen;
                        }
                    }

                    


                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conx);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                buscar("AND 1=1");
            }
            else
            {
                buscar("AND dni LIKE '%" + textBox1.Text + "%'");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            FilaClick(e);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ING_Load(object sender, EventArgs e)
        {
            button1_Click_1(null, e);

            ObtenerListaParametros("SELECT donde, id FROM [dbo].[donde]", dicDonde, "donde");
            ObtenerListaParametros("SELECT motivo, id FROM [dbo].[motivo]", dicMotivos, "motivo");
            
            List<string> listaDonde = new List<string>(dicDonde.Keys);
            List<string> listaMotivos = new List<string>(dicMotivos.Keys);
        // listaDonde = dicDonde.Keys;
        // listaMotivos = dicMotivos.Keys;
            LlenarComboBox(comboBox1, listaMotivos);
            LlenarComboBox(comboBox2, listaDonde);
        }

        private void LlenarComboBox(ComboBox elem, List<string> lista)
        {
            foreach (var item in lista)
            {
                elem.Items.Add(item);
            }
        }

        private void ObtenerListaParametros(string query, Dictionary<string, int> dic, string columna)
        {

            string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Define tu consulta SQL para obtener los parámetros

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        string valor;
                        string id;
                        string col_id = "id";
                        while (lector.Read())
                        {
                            valor = lector[columna].ToString();
                            id = lector[col_id].ToString();
                            dic.Add(valor, int.Parse(id));
                        }
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dni = textBox1.Text;
            string motivo = comboBox1.Text;
            string donde = comboBox2.Text;

            
            if (donde == "" || dni == "" || motivo == "")
            {
                MessageBox.Show("Los elementos que tienen los * no pueden estar vacíos.");
            }
            else if (MessageBox.Show("Por favor confirme antes de continuar" + "\n" + "Quieres continuar ? ", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.con.Open();
                int id_motivo = dicMotivos[motivo];
                int id_donde = dicDonde[donde];
                string sqlQuery = "INSERT into [dbo].[entra] (dni, tiempo_in, id_motivo, id_donde) VALUES ('" + dni + "', GETDATE(),'" + id_motivo + "','" + id_donde + "')";
                SqlCommand cmd = new SqlCommand(sqlQuery, this.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos se guardaron correctamente");

                this.con.Close();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new_reg form4 = new new_reg(conx);
            form4.ShowDialog();
        }
    }
}
