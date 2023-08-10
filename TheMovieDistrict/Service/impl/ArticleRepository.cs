using Microsoft.EntityFrameworkCore;
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

        public async Task<ArticleDto>? AddArticle(ArticleDto ArticleDto)            
        {
            _context.Articles.Add(Article.FromArticleDto(ArticleDto));
            var success = await _context.SaveChangesAsync() > 0;

            return success ? ArticleDto : null!;
        }

        public async Task<IEnumerable<ArticleDto>>? GetArticles()
        {
            var result = await _context.Articles.OrderByDescending(a => a.DateTime).ToListAsync();

            if (result.Any())
            {
                ICollection<ArticleDto> resultMapped = new List<ArticleDto>();
                foreach (Article articleFound in result.ToList())
                {
                    resultMapped.Add(ArticleDto.FromArticle(articleFound));
                }
                return resultMapped;
            }
            return null!;
        }

        public async Task<ArticleDto>? GetArticleById(int Id)
        {
            var article = await _context.Articles.Where(m => m.Id == Id).FirstOrDefaultAsync();

            if (article == null)
            {
                return null!;
            } 

            return ArticleDto.FromArticle(article);
        }

        public async Task<ArticleDto>? UpdateArticle(ArticleDto ArticleDto)
        {
            var article = await _context.Articles.FindAsync(ArticleDto.Id);

            if (article != null)
            {
                _context.Entry(article).CurrentValues.SetValues(ArticleDto);
            }

            bool success = await _context.SaveChangesAsync() > 0;

            return success ? ArticleDto.FromArticle(article!) : null!;
        }

        public async Task<ArticleDto>? DeleteArticle(int Id)
        {
            var article = await _context.Articles.FindAsync(Id);

            if (article == null)
            {
                return null!;
            }
            _context.Articles.Remove(article);

            bool success = await _context.SaveChangesAsync() > 0;

            return success ? ArticleDto.FromArticle(article) : null!;
        }
    }
}
