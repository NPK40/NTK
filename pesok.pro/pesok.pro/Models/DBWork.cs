using pesok.pro.Context;

namespace pesok.pro.Models
{
    public class DBWork
    {

        PesokContext db =  new PesokContext();
        public List<MenuEntry> GetListMenu(string typeMenu)
        {
            List<MenuEntry> listMenu = new List<MenuEntry>();
            db = new PesokContext();
            if (db.MenuEntries.Count(x=>x.Section == typeMenu) >0 )
            {
                listMenu.AddRange(db.MenuEntries.Where(x => x.Section == typeMenu).OrderBy(s=>s.Priority));
            }
            return listMenu;
        }

        public Catalog GetPage(int id)
        {
            db = new PesokContext();
           
            Catalog page = new Catalog();
       

                if (db.Catalogs.Count(x => x.Id == id) > 0)
                {
                    page = db.Catalogs.First(x => x.Id == id) ;
                }
            

            return page;
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
