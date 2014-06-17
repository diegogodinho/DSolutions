﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Attributes;

namespace WebMVC.Controllers
{
    public class HomeAdminController : Controller
    {
        //
        // GET: /HomeAdmin/

        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}