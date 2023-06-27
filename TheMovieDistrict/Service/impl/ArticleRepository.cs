﻿using Microsoft.AspNetCore.Mvc;
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

            return success ? Article : null;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        public Article? GetArticleById(int id)
        {
            return _context.Articles.Where(m => m.Id == id).FirstOrDefault();
        }

        public Article? UpdateArticle([FromBody] Article Article)
        {
            var article = _context.Articles.Find(Article.Id);

            if (article != null)
            {
                _context.Entry(article).CurrentValues.SetValues(Article);
            }

            bool success = _context.SaveChanges() > 0;

            return success ? article : null;
        }
    }
}
