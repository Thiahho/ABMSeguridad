using abm.App.Models;
using abm.data.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abm.data.Repositories
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioService()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

       

        public bool ActualizarUsuario(Usuario usuario)
        {
            return true;
        }

        public Usuario BuscarUsuario(string nombre, string password)
        {
            throw new NotImplementedException();
        }
    }
}
