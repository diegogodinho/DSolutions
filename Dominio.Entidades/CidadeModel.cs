using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dominio.Entidades
{
    
    public class CidadeModel : BaseModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Sigla")]
        public string Sigla { get; set; }
    }
}
