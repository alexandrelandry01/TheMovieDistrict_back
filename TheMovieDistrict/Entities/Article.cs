using TheMovieDistrict.Models;

namespace TheMovieDistrict.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }

        public static Article FromArticleDto(ArticleDto ArticleDto)
        {
            return new Article
            {
                Id = ArticleDto.Id,
                Title = ArticleDto.Title,
                Content = ArticleDto.Content,
                DateTime = ArticleDto.DateTime
            };
        }
    }
}
