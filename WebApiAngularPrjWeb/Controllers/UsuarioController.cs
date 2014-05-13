using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dados;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class UsuarioController : ApiController
    {
        public IEnumerable<Usuario> GetUsuarios()
        {
            return (new Usuario().BuscarTodos());
        }
        
        public Usuario GetUsuario(int id)
        {
            return (new Usuario().BuscarPorId(id));
        }
    }
}
