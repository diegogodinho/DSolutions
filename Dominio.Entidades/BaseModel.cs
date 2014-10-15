using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dominio.Entidades
{    
    public class BaseModel
    {
        //[Required]
        //[DataType(DataType.Text)]
        //[DisplayName("ID")]
        //[Key]
        public int ID { get; set; }
    }
}
