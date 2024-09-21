using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.App.Models
{
    
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public String Tipo {  get; set; }
        public Usuario(string nombre, string password, String tipo)
        {
            Nombre = nombre;
            Password = password;
            Tipo = tipo;
        }
        protected string Apellido { get; set; }
        protected string Dni { get; set; }

        public Usuario() { }
    }
}

