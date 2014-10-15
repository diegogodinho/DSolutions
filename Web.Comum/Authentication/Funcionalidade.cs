using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Comum.Authentication
{
    public class Funcionalidade
    {
        public string NomeFuncionalidade { get; set; }
        public string CodigoFuncionalidade { get; set; }
        public int PermiteCriacao { get; set; }
        public int PermiteLeitura { get; set; }
        public int PermiteAlteracao { get; set; }
        public int PermiteExclusao { get; set; }
    }
}