using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dominio.Entidades
{    
    public class GrupoModel : BaseModel
    {
        //[Required]
        //[DataType(DataType.Text)]
        //[DisplayName("Nome")]
        public string NomeGrupo { get; set; }
    }
}
