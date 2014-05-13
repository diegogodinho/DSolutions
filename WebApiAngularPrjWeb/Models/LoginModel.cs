using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dados;

namespace WebApiAngularPrjWeb.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Papel { get; set; }

        public LoginModel BuscarUsuario(string login, string senha)
        {
            LoginModel retorno = new LoginModel();

            USUARIOUNIVERSUS usu = (from a in SingletonDBContext.Current.dbContext.USUARIOUNIVERSUS
                                    where a.LOGIN == login && a.SENHAPADRAO == senha
                                    select a).FirstOrDefault();
            if (usu != null)
            {
                retorno.Login = usu.LOGIN;
                retorno.Senha = usu.SENHAPADRAO;
                retorno.Papel = "Administrators";
                return retorno;
            }
            return null;
        }
    }
}