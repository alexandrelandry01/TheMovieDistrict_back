using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service
{
    public interface IArticleRepository
    {
        Article? AddArticle([FromBody] Article article);
        IEnumerable<Article> GetArticles();
    }
}
