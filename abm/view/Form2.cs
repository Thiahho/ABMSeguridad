using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tutos;

namespace abm
{
    public partial class prov : Form
    {

        SqlConnection con;
        string cuit;
        string id;
        string cony;
        main login;

        public prov(main login , string xy)
        {
            this.cony = xy;
            string connectionString = @"Data Source='" + cony + "';Initial Catalog=abm;Integrated Security=True";
            this.login = login;
            this.con = new SqlConnection(connectionString);
           

            InitializeComponent();

            
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                buscar("AND 1=1");
            }
            else
            {
                buscar("AND d.[donde] LIKE '%" + textBox1.Text + "%'" );
            }
        }

        private void buscar(String condicion)
        {
            SqlConnection con;
            string connectionString = @"Data Source='" + cony + "';Initial Catalog=abm;Integrated Security=True";
            con = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "entra");
            string query = "SELECT  e.[ID] , d.[donde]  AS [DEPERTAMENTO],[tiempo_in] AS [INGRESO],m.[motivo] AS [MOTIVO] ,p.nombre as [NOMBRE],p.ape AS [APELLIDO],p.dni AS [IDENTIFICACIÓN],p.foto AS [FOTO] FROM [dbo].[entra] e INNER JOIN [dbo].[motivo] m ON m.id = e.id_motivo INNER JOIN [dbo].[per]	p ON p.dni = e.dni INNER JOIN [dbo].[donde] d ON d.id = e.id_donde WHERE e.[id] NOT IN (SELECT [id_entra] FROM [dbo].[salida]) " + condicion;
            adapter.SelectCommand = new SqlCommand(query, con);

            DataSet ds = new DataSet("entra");

            adapter.Fill(ds);
            
            dataGridView1.DataSource = ds.Tables["entra"];
            dataGridView1.Refresh();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
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
            byte[] imagenBytes;

            if (fila != -1)
            {
                if (dataGridView1.Rows[fila].Cells[1].Value == null)
                {
                }
                else
                {
                    tfila = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                    this.cuit = tfila;
                    textBox1.Text = tfila;
                    tfila = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                    this.id = tfila;
                    label4.Text = "NOMBRE :" + dataGridView1.Rows[fila].Cells[4].Value.ToString();
                    label5.Text = "APELLIDO :" + dataGridView1.Rows[fila].Cells[5].Value.ToString();
                    label6.Text = "IDENTIFICACIÓN :" + dataGridView1.Rows[fila].Cells[6].Value.ToString();
                    label7.Text = "DEPERTAMENTO :" + dataGridView1.Rows[fila].Cells[1].Value.ToString();
                    label8.Text = "MOTIVO :" + dataGridView1.Rows[fila].Cells[3].Value.ToString();
                    label9.Text = "INGRESO :" + dataGridView1.Rows[fila].Cells[2].Value.ToString();
                }
                if (dataGridView1.Rows[fila].Cells[7].Value is System.DBNull)
                {
                    pictureBox1.Image = Properties.Resources._2;
                }
                else
                {
                    imagenBytes = (byte[])dataGridView1.Rows[fila].Cells[7].Value;
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        Image imagen = Image.FromStream(ms);

                        // Asignar la imagen al PictureBox para mostrarla
                        pictureBox1.Image = imagen;
                    }
                }
            }
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.login.pausarTimer();
            ING forming = new ING(cony);
            forming.ShowDialog();
         

        }

        

       

        private void button6_Click(object sender, EventArgs e)
        {

            string sqlQuery;
            
            if (this.cuit == null)
            {
                MessageBox.Show("No se ha seleccionado ningun", "Salida");
            }
            else if (MessageBox.Show("Por favor confirme antes de continuar" + "\n" + "Quieres continuar ? ", "Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.con.Open();
                sqlQuery = string.Format("INSERT INTO [dbo].[salida] (id_entra , sal_time ) VALUES('" + id + "', GETDATE())");
                SqlCommand cmd = new SqlCommand(sqlQuery, this.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos se guardaron correctamente");
                textBox1.Text = null;
                label4.Text = "NOMBRE :" + null; 
                label5.Text = "APELLIDO :" + null; 
                label6.Text = "IDENTIFICACIÓN :" + null; 
                label7.Text = "DEPERTAMENTO :" + null; 
                label8.Text = "MOTIVO :" + null; 
                label9.Text = "INGRESO :" + null;
                pictureBox1.Image = Properties.Resources.im2;
                this.cuit = null;


                button4_Click(null, e);
                this.con.Close();
                
              
            }

           
        }

        private void prov_Load(object sender, EventArgs e)
        {
            button4_Click(null, e);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }


       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                TextRenderer.DrawText(e.Graphics, "No se encontraron registros.",
                dataGridView1.Font, dataGridView1.ClientRectangle,
                dataGridView1.ForeColor, dataGridView1.BackgroundColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(this.id);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    }

