﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Authentication
{
    public class Profile
    {
        public string Login { get; set; }
        public Grupo Grupo { get; set; }
    }
}