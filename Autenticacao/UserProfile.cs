using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Autenticacao
{
    public class UserProfile : IPrincipal
    {
        public List<string> Papeis { get; set; }

        public UserProfile(UserIdentity identity)
        {
            this.identity = identity;
            Papeis = new List<string>();
        }

        private UserIdentity identity;

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            return Papeis.Contains(role);
        }
    }
}
