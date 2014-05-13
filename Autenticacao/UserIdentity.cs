using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Autenticacao
{
    public class UserIdentity : IIdentity
    {
        private string name;

        public UserIdentity(string name)
        {
            this.name = name;
        }
        public UserIdentity()
        {

        }

        public string AuthenticationType
        {
            get { return "Form"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}
