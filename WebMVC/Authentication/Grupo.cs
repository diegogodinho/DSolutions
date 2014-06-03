using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Authentication
{
    public class Grupo
    {
        public string Nome { get; set; }
        public List<Funcionalidade> Funcionalidades { get; set; }
    }
}