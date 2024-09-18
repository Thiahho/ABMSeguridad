using abm.App.Models;
using abm.data.Repositories;
using abm.data.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace abm.data.Controllers
{
    internal class HistorialController
    {
        private readonly IHistorialService _historialService;
        
        public HistorialController(IHistorialService historialService)
        {
            _historialService = historialService;
        }
        public List<Registro> BuscarPersona(string condicion,DateTime desde,DateTime hasta)
        {
            var registros= _historialService.BuscarPersona(condicion, desde, hasta);
            return registros;
        }
       
        
    }
}
