using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service
{
    public interface IArticleRepository
    {
        ArticleDto? AddArticle(ArticleDto ArticleDto);
        IEnumerable<ArticleDto>? GetArticles();
        ArticleDto? GetArticleById(int Id);
        ArticleDto? UpdateArticle(ArticleDto ArticleDto);
        bool DeleteArticle(int Id);
    }
}
