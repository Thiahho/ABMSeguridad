using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.App.Models
{
    public class Entra
    {
        protected int Id { get; set; }
        protected DateTime TiempoIn { get; set; }
        protected int IdMotivo { get; set; }
        protected string Dni { get; set; }
        protected int IdDonde { get; set; }
    }
}
