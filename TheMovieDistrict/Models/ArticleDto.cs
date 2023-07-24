using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Models
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }

        public static ArticleDto FromArticle(Article Article)
        {
            return new ArticleDto
            {
                Id = Article.Id,
                Title = Article.Title,
                Content = Article.Content,
                DateTime = Article.DateTime
            };
        }
    }
}
