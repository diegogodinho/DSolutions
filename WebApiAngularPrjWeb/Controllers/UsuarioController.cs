using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dados;
using WebApiAngularPrjWeb.Models;

namespace WebApiAngularPrjWeb.Controllers
{

    public class UsuarioController : ApiController
    {
        public IEnumerable<Usuario> GetUsuarios()
        {
            return (Usuario.BuscarTodos());
        }

        //[Authorize(Roles = "Administrators")]        
        public Usuario GetUsuario(int id)
        {
            return (Usuario.BuscarPorId(id));
        }



    }
}
