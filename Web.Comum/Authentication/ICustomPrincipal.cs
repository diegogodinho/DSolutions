using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Web.Comum.Authentication
{
    public interface ICustomPrincipal : IPrincipal
    {
        bool PermiteAcessoAFuncionalidade(string funcionalidade);
        bool PermiteAcessoAAcao(string funcionalidade, Acao acao);
    }
}
