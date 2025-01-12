﻿using Microsoft.AspNetCore.Mvc;
using pesok.pro.Models;
using System.Diagnostics;
using pesok.pro.Models;
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
            ViewBag.Header = "Цены";
            return View();
        }

        [Route("Cooperation")]
        public IActionResult Cooperation()
        {
            ViewBag.Header = "Сотрудничество";
            return View();
        }

        
     
        [Route("service/{url?}")]
        public IActionResult Service(string url = "plot_filling")
        {
            DBWork db = new DBWork();
            MenuEntry entry = new MenuEntry();
            entry = db.GetMenu(url);
            ViewBag.TypeMenu = "Service";

            if (entry.Indx != 0)
            {
                Catalog page = db.GetPage(entry.Indx);
                ViewBag.Context = page.Html;
                ViewBag.Title = entry.Title;
                ViewBag.KeyWord = page.Keywords;
                ViewBag.Description = page.Description;
                ViewBag.Header = "Услуги";
                ViewBag.NamePage = entry.Header;
                ViewBag.Url = url;
            }

            // if (page.Html != "")
            return View();
            // else return HttpNotFound();
        }


       [Route("catalog/{url?}")]
        public IActionResult Catalog( string url = "sand")
        {
            DBWork db = new DBWork();
            MenuEntry entry = new MenuEntry();
            entry = db.GetMenu(url);
            ViewBag.TypeMenu = "Catalog";
            ViewBag.Url = url;

            if (entry.Indx != 0)
            {
                Catalog page = db.GetPage(entry.Indx);
                ViewBag.Context = page.Html;
                ViewBag.Title = entry.Title;
                ViewBag.KeyWord = page.Keywords;
                ViewBag.Description = page.Description;
                ViewBag.NamePage = entry.Header;
               ViewBag.Header = "Каталог";
                
            }
           
           // if (page.Html != "")
                return View();
           // else return HttpNotFound();
        }

        [Route("About")]
        public ActionResult About()
        {

            ViewBag.Header = "О нас";
            return View();
        }

        

       [Route("Contacts")]
        public IActionResult Contacts()
        {

            ViewBag.Header = "Контакты";
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
