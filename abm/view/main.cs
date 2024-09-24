﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using abm.App.Models;
using abm.view;

namespace abm
{
    public partial class main : Form
    {
        List<Usuario>usuarios= new List<Usuario>(); 
        string conn= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string tipoUsuario;
        public main(string tipo)
        {

            this.tipoUsuario= tipo;


            InitializeComponent();
            if (tipo == "1") // Administrador
            {
                button1.Visible = true;
                bEditar.Visible = true;
                provx.Visible = true;

            }
            else
            {
                button1.Visible = false;
                bEditar.Visible = false;
            }
            
            


        }

        public void pausarTimer()
        {
            timer1.Enabled = false;
        }

        public void activarTimer()
        {
            timer1.Enabled = true;
        }

        private void openhoja(object formhoja)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form fh = formhoja as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(fh);
            this.panel2.Tag = fh;
            fh.Show();


        }


        private void provx_Click(object sender, EventArgs e)
        {
            
            openhoja(new prov(this , conn));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] 
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
                        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
      
  

        private void button1_Click(object sender, EventArgs e)
        {
            openhoja(new his_view(conn));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ogmaintodo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(panel1.Width== 232){

                panel1.Width = 58;

            }
            else
            {
                panel1.Width = 232;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //openhoja(new logo(conn));
            
        }

        private void main_Load(object sender, EventArgs e)
        {
            pictureBox1_Click(null, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new AgregarYModificarUsuario();
            //MessageBox.Show(usuario.Tipo.ToString());
            form.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1_Click(null, e);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //openhoja(new logo(conn));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openhoja(new Form4());
        }
    }
}
