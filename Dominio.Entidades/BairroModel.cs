using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Dominio.Entidades
{    
    public class BairroModel : BaseModel
    {
        [Required]
        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Cidade")]
        public CidadeModel Cidade { get; set; }

        [Required]
        [DisplayName("Sigla")]
        [DataType(DataType.Text)]
        public string Sigla { get; set; }

        [DisplayName("Selecione a cidade")]
        public List<SelectListItem> CidadesDisponiveis { get; set; }
    }
}
