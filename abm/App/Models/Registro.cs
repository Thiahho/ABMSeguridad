using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.App.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public DateTime? HoraDeIngreso { get; set; }
        public DateTime? HoraDeSalida { get; set; }
        public string Motivo { get; set; }
        
        public Registro(int id,string identificacion, string nombre, string apellido, string departamento, DateTime horaDeIngreso, DateTime horaDeSalida, string motivo)
        {
            this.Id = id;
            this.Identificacion = identificacion;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Departamento = departamento;
            this.HoraDeIngreso = horaDeIngreso;
            this.HoraDeSalida = horaDeSalida;
            this.Motivo = motivo;
        }
       
        public Registro()
        {
            this.Identificacion = string.Empty;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Departamento = string.Empty;
            this.HoraDeIngreso = null;
            this.HoraDeSalida = null;
            this.Motivo = string.Empty;
        }
       
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
 