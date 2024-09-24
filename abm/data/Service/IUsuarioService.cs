using abm.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.data.Repositories
{
    public interface IUsuarioService
    {
        Usuario BuscarUsuario(string nombre, string password);
        bool ActualizarUsuario(Usuario usuario);
    }
}
