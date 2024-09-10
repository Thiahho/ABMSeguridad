using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abm
{
    public partial class Form1x : Form
    {
        private string PathPhotos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Photos");
        private bool HayDipositivos;
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MiWebCam;
        byte[] img;
        new_reg form;

        public Form1x(new_reg form)
        {
            this.form = form;
            this.form.set_foto(null);
            InitializeComponent();
            CargaDispositivos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargaDispositivos();
        }

        public void CargaDispositivos()
        {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if(MisDispositivos.Count > 0)
            {
                HayDipositivos = true;
                for(int i = 0; i < MisDispositivos.Count; i++)
                {
                    comboBox1.Items.Add(MisDispositivos[i].Name.ToString());
                }
                comboBox1.Text = MisDispositivos[0].ToString();
            }
            else
            {
                HayDipositivos = false;
            }


        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = Imagen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
            int i = comboBox1.SelectedIndex;
            string NombreVideo = MisDispositivos[i].MonikerString;
            MiWebCam = new VideoCaptureDevice(NombreVideo);
            MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
            MiWebCam.Start();
            
        }

        private void CerrarWebCam()
        {
            if(MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                pictureBox2.Image = pictureBox1.Image;
                //pictureBox2.Image.Save(PathPhotos + "\\default.jpeg", ImageFormat.Jpeg);
                this.form.set_foto(pictureBox2.Image);
                this.Close();
            }
        }

    }
}
