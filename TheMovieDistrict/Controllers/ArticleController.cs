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

        [HttpGet("{id}")]
        public ActionResult<ArticleDto> GetArticleById(int id)
        {
            var article = _articleRepository.GetArticleById(id);

            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost("addarticle")]
        [ProducesResponseType(typeof(Article), 200)]
        [ProducesResponseType(404)]
        public ActionResult<ArticleDto> AddArticle([FromBody] Article Article)
        {
            Article.DateTime = DateTime.Now;

            return Ok(_articleRepository.AddArticle(Article));
        }

        [HttpPut("updatearticle/{id}")]
        public ActionResult<ArticleDto> UpdateArticle([FromBody] Article Article)
        {
            var updatedArticle = _articleRepository.UpdateArticle(Article);

            return Ok(updatedArticle);
        }

        [HttpDelete("deletearticle/{id}")]
        public ActionResult DeleteArticle(int id) {
            bool articleDeleted = _articleRepository.DeleteArticle(id);

            if (articleDeleted)
            {
                return Ok(articleDeleted);
            }
            return BadRequest("Article was not found");
        }
    }
}
