using System;
using System.Collections.Generic;

namespace pesok.pro.Models
{
    public partial class Catalog
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Keywords { get; set; }
        public string? Minitext { get; set; }
        public DateTime? Date { get; set; }
        public byte[]? Image { get; set; }
        public float? Priority { get; set; }
        public string? Html { get; set; }
    }
}
