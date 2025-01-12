using System;
using System.Collections.Generic;

namespace pesok.pro.Models
{
    public partial class MenuEntry
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public bool Visible { get; set; }
        public string Section { get; set; } = null!;
        public string? Razdel { get; set; }
        public string? Header { get; set; }
        public string? Title { get; set; }
        public int Indx { get; set; }

        public int Priority { get; set; }
    }
}
