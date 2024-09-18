using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.App.Models
{
    public class Registro
    {
        public string Departamento { get; set; }
        public DateTime? HoraDeIngreso { get; set; }
        public DateTime? HoraDeSalida { get; set; }
        public string Motivo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }


        public Registro(string Identificacion, string Nombre, string Apellido, string Departamento, DateTime HoraDeIngreso, DateTime HoraDeSalida, string Motivo)
        {
            this.Identificacion = Identificacion;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Departamento = Departamento;
            this.HoraDeIngreso = HoraDeIngreso;
            this.HoraDeSalida = HoraDeSalida;
            this.Motivo = Motivo;
        }

    }
}
 