namespace TheMovieDistrict.Models
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
