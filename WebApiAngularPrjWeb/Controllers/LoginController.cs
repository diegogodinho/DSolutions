using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAngularPrjWeb.Models;
using Autenticacao;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace WebApiAngularPrjWeb.Controllers
{
    public class LoginController : ApiController
    {
        public void AutenticarUsuario(LoginModel login)
        {
            //LoginModel usuarioRetorno = login.BuscarUsuario(login.Login, login.Senha);
            //if (usuarioRetorno != null)
            //{                
            //    UserProfile userProfile = new UserProfile(new UserIdentity(usuarioRetorno.Login));
            //    userProfile.Papeis.Add(usuarioRetorno.Papel);

            //    Thread.CurrentPrincipal = userProfile;

            //    if (HttpContext.Current != null)
            //    {
            //        HttpContext.Current.User = userProfile;
            //    }
            //    //FormsAuthentication.SetAuthCookie(userProfile.Identity.Name , false);
            //}
        }
    }
}
