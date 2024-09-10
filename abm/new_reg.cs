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

namespace abm
{
    public partial class new_reg : Form
    {
        SqlConnection con;
        string conx;
        Image imagen;
        Image foto;

        public new_reg(string conx)
        {
            this.conx = conx;

            string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";
            this.con = new SqlConnection(connectionString);
            InitializeComponent();
        }

        public void set_foto(Image nueva_foto)
        {
            this.foto = nueva_foto;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.con.Open();
            String cuitx = cuit.Text;
            String nameusu = usu.Text.Replace("'", "").Replace(" ", "").Replace("\"", "");
            String nameape = ape.Text.Replace("'", "").Replace(" ", "").Replace("\"", "");

            Image testImage = this.foto;

            if (System.Text.RegularExpressions.Regex.IsMatch(cuit.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor ingrese solo números DNI.");
                cuit.Text = cuit.Text.Remove(cuit.Text.Length - 1);
            }
            else if (ape != null && !string.IsNullOrWhiteSpace(ape.Text) && usu != null && !string.IsNullOrWhiteSpace(usu.Text) && cuit != null && !string.IsNullOrWhiteSpace(cuit.Text))
            {
                byte[] imagenBytes = null;
                if (testImage != null)
                {
                    // Convertir la imagen en un arreglo de bytes
                    using (MemoryStream ms = new MemoryStream())
                    {
                        testImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imagenBytes = ms.ToArray();
                    }
                }
                
                string sqlQuery = "INSERT into [dbo].[per] (dni,nombre,Ape, Foto) VALUES ('" + cuitx + "', '" + nameusu + "','" + nameape + "', @Imagen)";
                SqlCommand cmd = new SqlCommand(sqlQuery, this.con);
                SqlParameter param = new SqlParameter("@Imagen", System.Data.SqlDbType.Image);
                
                if (imagenBytes != null)
                {
                    param.Value = imagenBytes;
                    cmd.Parameters.Add(param);
                }
                else
                {
                    sqlQuery = sqlQuery.Replace("@Imagen", "NULL");
                    cmd = new SqlCommand(sqlQuery, this.con);
                }
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos se guardaron correctamente" );
                if (testImage != null)
                {
                    testImage.Dispose();
                }

            }
            else
            {

                MessageBox.Show("Los elementos que tienen los * no pueden estar vacíos.");


            }

            this.con.Close();
            this.Close();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.foto = null;

            Form1x form5 = new Form1x(this);
            form5.ShowDialog();

            pictureBox1.Image = this.foto;
        }
    }
}
