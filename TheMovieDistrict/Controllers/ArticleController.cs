using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Models;
using TheMovieDistrict.Service;

namespace TheMovieDistrict.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository ??
                throw new ArgumentNullException(nameof(articleRepository));
        }

        [HttpPost("addarticle")]
        public ActionResult<ArticleDto> AddArticle([FromBody] ArticleDto ArticleDto)
        {
            ArticleDto.DateTime = DateTime.Now;

            return Ok(_articleRepository.AddArticle(ArticleDto));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleDto>> GetArticles()
        {
            var articles = _articleRepository.GetArticles();

            if (articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public ActionResult<ArticleDto> GetArticleById(int Id)
        {
            var article = _articleRepository.GetArticleById(Id);

            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPut("updatearticle/{id}")]
        public ActionResult<ArticleDto> UpdateArticle([FromBody] ArticleDto ArticleDto)
        {
            return Ok(_articleRepository.UpdateArticle(ArticleDto));
        }

        [HttpDelete("deletearticle/{id}")]
        public ActionResult DeleteArticle(int Id) {
            bool articleDeleted = _articleRepository.DeleteArticle(Id);

            if (articleDeleted)
            {
                return Ok(articleDeleted);
            }
            return BadRequest("Article was not found");
        }
    }
}
