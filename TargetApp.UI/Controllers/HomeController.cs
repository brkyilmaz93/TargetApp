using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TargetApp.UI.Models;

namespace TargetApp.UI.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _cfg;
        string WebApiUrl = "";

        public HomeController(IConfiguration cfg)
        {
            _cfg = cfg;

            WebApiUrl = cfg.GetValue<string>("WebApiLoginUrl");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

     

       
    }
}
