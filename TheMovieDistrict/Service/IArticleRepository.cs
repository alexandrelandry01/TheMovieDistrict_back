using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service
{
    public interface IArticleRepository
    {
        Task<ArticleDto>? AddArticle(ArticleDto ArticleDto);
        Task<IEnumerable<ArticleDto>>? GetArticles();
        Task<ArticleDto>? GetArticleById(int Id);
        Task<ArticleDto>? UpdateArticle(ArticleDto ArticleDto);
        Task<ArticleDto>? DeleteArticle(int Id);
    }
}
