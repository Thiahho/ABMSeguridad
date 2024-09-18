using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace abm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
    }
    class adm
    {
        static void Form4(string[] args)
        {
            // Precio base
            decimal precioBase = 100m;

            // Factor de multiplicación
            decimal factor = 1.2m;

            // Nuevo precio
            decimal nuevoPrecio = precioBase * factor;

            // Ruta de la imagen original
            string rutaImagenOriginal = "ruta/a/tu/imagen.png";

            // Ruta de la imagen modificada
            string rutaImagenModificada = "ruta/a/tu/imagen_modificada.png";

            // Cargar la imagen
            using (Image imagen = Image.FromFile(rutaImagenOriginal))
            {
                // Crear un bitmap a partir de la imagen
                using (Bitmap bitmap = new Bitmap(imagen))
                {
                    // Crear un formulario para la previsualización
                    Form form = new Form();
                    form.Text = "Previsualización de la Imagen";
                    form.ClientSize = new Size(bitmap.Width, bitmap.Height);
                    form.StartPosition = FormStartPosition.CenterScreen;

                    // Añadir un PictureBox para mostrar la imagen
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Image = bitmap;
                    form.Controls.Add(pictureBox);

                    // Mostrar el formulario y esperar la posición del texto
                    PointF posicionTexto = ObtenerPosicionTexto(form, bitmap, $"Precio: {nuevoPrecio:C}");

                    // Crear un objeto Graphics a partir del bitmap
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Definir la fuente y el color del texto
                        Font fuente = new Font("Arial", 24, FontStyle.Bold);
                        Brush brocha = new SolidBrush(Color.Black);

                        // Dibujar el nuevo precio en la imagen en la posición seleccionada
                        g.DrawString($"Precio: {nuevoPrecio:C}", fuente, brocha, posicionTexto);

                        // Guardar la imagen modificada
                        bitmap.Save(rutaImagenModificada);
                    }

                    Console.WriteLine("Imagen modificada con éxito.");
                }
            }
        }

        // Método para obtener la posición del texto
        static PointF ObtenerPosicionTexto(Form form, Bitmap bitmap, string texto)
        {
            PointF posicionTexto = new PointF(10, 10);
            bool posicionConfirmada = false;

            // Controlador de eventos para el clic del mouse en el formulario
            form.MouseClick += (sender, e) =>
            {
                posicionTexto = new PointF(e.X, e.Y);
                posicionConfirmada = true;
                form.Close();
            };

            // Mostrar el formulario
            form.ShowDialog();

            // Confirmar la posición
            if (!posicionConfirmada)
            {
                throw new Exception("Posición del texto no confirmada.");
            }

            return posicionTexto;
        }
    }
}
