using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class PesquisaPrincipalModel
    {
        public List<SelectListItem> Cidades { get; set; }
        public List<SelectListItem> Bairros { get; set; }
    }
}