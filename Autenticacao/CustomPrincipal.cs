using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Autenticacao
{
    public class CustomPrincipal : IPrincipal
    {
        public List<string> Papeis { get; set; }

        public string Nome { get; private set; }
        public string Email { get; private set; }

        public CustomPrincipal(string nome, List<string> papeis)
        {
            Nome = nome;
            Identity = new GenericIdentity(nome);
            Papeis = papeis;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return Papeis.Contains(role);
        }
    }
}
