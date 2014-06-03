using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebMVC.Models
{
    public class BaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("ID")]
        public int ID { get; set; }
    }
}