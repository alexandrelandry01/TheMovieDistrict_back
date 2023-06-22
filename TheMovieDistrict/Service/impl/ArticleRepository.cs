using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMovieDistrict.Data;
using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service.impl
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Article? AddArticle([FromBody] Article Article)
        {
            _context.Articles.Add(Article);
            var success = _context.SaveChanges() > 0;

            if (success)
            {
                return Article;
            }
            return null;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }
    }
}
