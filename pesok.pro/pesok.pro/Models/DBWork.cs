using Microsoft.CodeAnalysis.CSharp.Syntax;
using pesok.pro.Context;
using System;

namespace pesok.pro.Models
{
    public class DBWork
    {

        PesokContext db = new PesokContext();
        public List<MenuEntry> GetListMenu(string typeMenu)
        {
            List<MenuEntry> listMenu = new List<MenuEntry>();
            db = new PesokContext();
            if (db.MenuEntries.Count(x => x.Section == typeMenu) > 0)
            {
                if (typeMenu != "ArticleMenu")
                {
                    listMenu.AddRange(db.MenuEntries.Where(x => x.Section == typeMenu).OrderBy(s => s.Priority));
                }
                else {
                    listMenu = db.MenuEntries.Where(x => x.Section == typeMenu && x.Url != "/article").GroupBy(x => x.Razdel).Select(o => new MenuEntry {
                        Header = o.First().Header,
                        Url = o.Key
                    }).OrderBy(s => s.Header).ToList();
                }
            }
            return listMenu;
        }

        public Catalog GetPage(int id)
        {
            db = new PesokContext();

            Catalog page = new Catalog();


            if (db.Catalogs.Count(x => x.Id == id) > 0)
            {
                page = db.Catalogs.First(x => x.Id == id);
            }


            return page;
        }

        public string convertShortTime(DateTime? date)
        {
          string d = "";

            if (date != null)
            {
                DateTime d2 = (DateTime)date;
                d = d2.ToShortTimeString();
            }
            return d;

        }

        public List<ArticleListPage> GetListArticle(string razdel)
        {
            db = new PesokContext();
            List<ArticleListPage> list = new List<ArticleListPage>();
            list = db.MenuEntries.Where(x => x.Section == "ArticleMenu" && x.Razdel == razdel && x.Visible == true).Join(db.Articles, p => p.Indx, x => x.Id, (p, x) => new ArticleListPage { 
            Id = p.Id,
            Header = p.Header,
            Url = p.Url,
            Description =  x.Description,
            Date= ((DateTime)x.Date).ToString("dd.MM.yyyy"),
  //          Html = x.Html,
            Indx = p.Indx,
            Image = x.Image,
            Image_Src = x.Image_Src,
            Keywords = x.Keywords,
            Minitext = x.Minitext,
            Priority = p.Priority,
            Razdel = p.Razdel,
            Title = p.Title,
            }).ToList();

            return list;
        }

        public List<ArticleListPage> GetListArticle(string razdel, string url)
        {
            db = new PesokContext();
            List<ArticleListPage> list = new List<ArticleListPage>();
            list = db.MenuEntries.Where(x => x.Section == "ArticleMenu" && x.Razdel == razdel && x.Visible == true && x.Url == url).Join(db.Articles, p => p.Indx, x => x.Id, (p, x) => new ArticleListPage
            {
                Id = p.Id,
                Header = p.Header,
                Url = p.Url,
                Description = x.Description,
                Date = ((DateTime)x.Date).ToString("dd.MM.yyyy"),
                Html = x.Html,
                Indx = p.Indx,
                Image = x.Image,
                Image_Src = x.Image_Src,
                Keywords = x.Keywords,
                Minitext = x.Minitext,
                Priority = p.Priority,
                Razdel = p.Razdel,
                Title = p.Title,
            }).ToList();

            return list;
        }

        public MenuEntry GetMenu(string url)
        {
            db = new PesokContext();
            MenuEntry menu = new MenuEntry();
           
            if (db.MenuEntries.FirstOrDefault(x => x.Url == url) != null)
            {
                menu = db.MenuEntries.First(x => x.Url == url);

            }

            return menu;
        }
    }
}
