using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Data;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service.impl
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticleDto? AddArticle(ArticleDto ArticleDto)            
        {
            _context.Articles.Add(Article.FromArticleDto(ArticleDto));
            var success = _context.SaveChanges() > 0;

            return success ? ArticleDto : null;
        }

        public IEnumerable<ArticleDto>? GetArticles()
        {
            IEnumerable<Article> result = _context.Articles.OrderByDescending(a => a.DateTime);

            if (result.Any())
            {
                ICollection<ArticleDto> resultMapped = new List<ArticleDto>();
                foreach (Article articleFound in result.ToList())
                {
                    resultMapped.Add(ArticleDto.FromArticle(articleFound));
                }
                return resultMapped;
            }
            return null;
        }

        public ArticleDto? GetArticleById(int Id)
        {
            var article = _context.Articles.Where(m => m.Id == Id).FirstOrDefault();

            if (article == null)
            {
                return null;
            } 

            return ArticleDto.FromArticle(article);
        }

        public ArticleDto? UpdateArticle(ArticleDto ArticleDto)
        {
            var article = _context.Articles.Find(ArticleDto.Id);

            if (article != null)
            {
                _context.Entry(article).CurrentValues.SetValues(ArticleDto);
            }

            bool success = _context.SaveChanges() > 0;

            return success ? ArticleDto : null;
        }

        public bool DeleteArticle(int Id)
        {
            var article = _context.Articles.Find(Id);

            if (article == null)
            {
                return false;
            }
            _context.Articles.Remove(article);
            
            return _context.SaveChanges() > 0;
        }
    }
}
