using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Service;
using TheMovieDistrict.Models;
using Microsoft.AspNetCore.Authorization;

namespace TheMovieDistrict.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository ?? 
                throw new ArgumentNullException(nameof(movieRepository));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addmovie")]
        public async Task<ActionResult<MovieDto>> AddMovie([FromBody] MovieDto MovieDto)
        {
            MovieDto.CreationDate = DateTime.Now;

            return Ok(await _movieRepository.AddMovie(MovieDto)!);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _movieRepository.GetMovies()!;

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("findbycountry/{country}")]
        public async Task<ActionResult<MovieDto>> GetMoviesByCountry(string country)
        {
            var movies = await _movieRepository.GetMoviesByCountry(country)!;

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("findbycountry/{country}/{territory}")]
        public async Task<ActionResult<MovieDto>> GetMoviesByCountryAndTerritory(string country, string territory)
        {
            var movies = await _movieRepository.GetMoviesByCountryAndTerritory(country, territory)!;

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovieById(int Id)
        {
            var movie = await _movieRepository.GetMovieById(Id)!;
            
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("latestmovies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetLatestMovies() {
            var movies = await _movieRepository.GetLatestMovies()!;

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("search/{searchParam}")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetSearchResults(string searchParam)
        {
            var movies = await _movieRepository.GetSearchResults(searchParam)!;

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatemovie/{id}")]
        public async Task<ActionResult<MovieDto>> UpdateMovie([FromBody] MovieDto MovieDto)
        {
            var movie = await _movieRepository.UpdateMovie(MovieDto)!;

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        } 
    }
}
