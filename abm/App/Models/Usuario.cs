using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.App.Models
{
    
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Tipo {  get; set; }
        protected string Apellido { get; set; }
        protected string Dni { get; set; }

        public Usuario(int id,string nombre, string password, int tipo)
        {
            Id = id;
            Nombre = nombre;
            Password = password;
            Tipo = tipo;
        }
      
        public Usuario() { }
    }
}

