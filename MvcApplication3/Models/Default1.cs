using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication3.Models
{
    public class Default1 
    {

        [Required]
        public int MyProperty { get; set; }

    }
}
