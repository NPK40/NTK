using pesok.pro.Models;
using System;
using Microsoft.AspNetCore.Mvc;

namespace pesok.pro.Components
{

    public class MenuProduct : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            DBWork _db = new DBWork();
            string typemenu = "CatalogMenu";
            var menu = ViewBag.TypeMenu;
            if (menu == "Service" )
            {
                typemenu = "ServiceMenu";
            }
            if (menu == "Article")
            {
                typemenu = "ArticleMenu";
            }


            List<MenuEntry> prodmenu = _db.GetListMenu(typemenu);
            return View("MenuProductView", prodmenu); 
        }
    }
}
