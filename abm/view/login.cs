using abm.App.Models;
using abm.data.Repositories;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abm
{
    public partial class login : Form
    {
        private readonly IUsuarioService _usuarioService;
        public login()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
        }

        private void usu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = usu.Text;
            string password = pas.Text;

            Usuario usuario = _usuarioService.BuscarUsuario(nombre, password);

            if (usuario != null)
            {
                //MessageBox.Show("Inicio de sesión exitoso.");
                // Aquí puedes abrir otra ventana o realizar otra acción después de un inicio de sesión exitoso.
                Form form = new main(usuario.Tipo.ToString());
                //MessageBox.Show(usuario.Tipo.ToString());
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
