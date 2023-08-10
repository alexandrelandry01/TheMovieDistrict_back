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
        public async Task<ActionResult<ArticleDto>> AddArticle([FromBody] ArticleDto ArticleDto)
        {
            ArticleDto.DateTime = DateTime.Now;

            return Ok(await _articleRepository.AddArticle(ArticleDto)!);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {
            var articles = await _articleRepository.GetArticles()!;

            if (articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticleById(int Id)
        {
            var article = await _articleRepository.GetArticleById(Id)!;

            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPut("updatearticle/{id}")]
        public async Task<ActionResult<ArticleDto>> UpdateArticle([FromBody] ArticleDto ArticleDto)
        {
            var article = await _articleRepository.UpdateArticle(ArticleDto)!;

            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpDelete("deletearticle/{id}")]
        public async Task<ActionResult<ArticleDto>> DeleteArticle(int Id) {
            var articleDeleted = await _articleRepository.DeleteArticle(Id)!;

            if (articleDeleted == null)
            {
                return NotFound();
            }
            return Ok(articleDeleted);
        }
    }
}
