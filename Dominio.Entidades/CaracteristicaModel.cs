using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dominio.Entidades
{    
    public class CaracteristicaModel : BaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
