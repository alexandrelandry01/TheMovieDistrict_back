using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;
using TheMovieDistrict.Service;

namespace TheMovieDistrict.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleController(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository ??
                throw new ArgumentNullException(nameof(articleRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleDto>> GetArticles()
        {
            var articles = _articleRepository.GetArticles();

            return Ok(articles);
        }

        [HttpPost("addarticle")]
        [ProducesResponseType(typeof(Article), 200)]
        [ProducesResponseType(404)]
        public Article? AddArticle([FromBody] Article Article)
        {
            Article.DateTime = DateTime.Now;
            return _articleRepository.AddArticle(Article);
        }
    }
}
