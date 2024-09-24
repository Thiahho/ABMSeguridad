using abm.App.Models;
using abm.data.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
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

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _usuarioRepositorio.ObtenerUsuarioPorId(id);
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            return _usuarioRepositorio.ActualizarUsuario(usuario);
        }

        public Usuario BuscarUsuario(string nombre, string password)
        {
            throw new NotImplementedException();
        }
    }

}
