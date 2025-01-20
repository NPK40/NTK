namespace pesok.pro.Models
{
    public class ArticleListPage
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public string? Razdel { get; set; }
        public string? Header { get; set; }
        public string? Title { get; set; }
        public int Indx { get; set; }

        public int Priority { get; set; }

        public string? Description { get; set; }
        public string? Keywords { get; set; }
        public string? Minitext { get; set; }
        public String Date { get; set; }
        public byte[]? Image { get; set; }
       
        public string? Html { get; set; }
        public string? Image_Src { get; set; }
    }
}
