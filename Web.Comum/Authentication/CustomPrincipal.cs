using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace Web.Comum.Authentication
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public string Nome { get; private set; }
        public Grupo Grupo { get; private set; }

        public CustomPrincipal(string nome, Grupo grupo)
        {
            Nome = nome;
            Identity = new GenericIdentity(nome);
            Grupo = grupo;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return Grupo.Nome.ToUpper() == role.ToUpper();
        }

        public bool PermiteAcessoAFuncionalidade(string funcionalidade)
        {
            throw new NotImplementedException();
        }

        public bool PermiteAcessoAAcao(string funcionalidade, Acao acao)
        {
            throw new NotImplementedException();
        }
    }
}