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

namespace abm
{
    public partial class logo : Form
    {
        SqlConnection con;
        string conx;
        public logo(string conx)
        {
           
          //CACA
            this.conx = conx;
            InitializeComponent();
            string connectionString = @"Data Source='" + conx + "';Initial Catalog=abm;Integrated Security=True";
            this.con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM[dbo].[entra] e WHERE e.id NOT IN(SELECT s.id_entra FROM[dbo].[salida] s)", this.con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                label4.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                label4.Text = "0";
            }
            con.Close();
        }

        private void HORA_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void logo_Load(object sender, EventArgs e)
        {
           // "SELECT COUNT(*) FROM[dbo].[entra] e WHERE e.id NOT IN(SELECT s.id_entra FROM[dbo].[salida] s)"
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
