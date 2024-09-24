using abm.App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.data.Repositories
{
    public interface IHistorialService
    {
        //Registro buscarPersona(DateTime desde, DateTime hasta, string condicion); 
        List<Registro> BuscarRegistro(string condicion, DateTime desde, DateTime hasta);
        void ExportarCsv(List<Registro> registros, string ruta, string separador);
        Registro ObtenerRegistroPorId(int id);
    }
}
