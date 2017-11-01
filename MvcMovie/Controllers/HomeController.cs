﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Movie");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "CSIS 4135 Web App Engineering";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "CSIS 4135 Web App Engineering";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
