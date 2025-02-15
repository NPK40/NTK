﻿using Microsoft.AspNetCore.Mvc;
using pesok.pro.Models;
using System.Diagnostics;

namespace pesok.pro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Price")]
        public IActionResult Price()
        {
            return View();
        }

        [Route("Cooperation")]
        public IActionResult Cooperation()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            

            return View();
        }

        

       [Route("Contacts")]
        public IActionResult Contacts()
        {


            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
