using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Service;
using TheMovieDistrict.Models;

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

        [HttpPost("addmovie")]
        public ActionResult<MovieDto> AddMovie([FromBody] MovieDto MovieDto)
        {
            MovieDto.CreationDate = DateTime.Now;

            return Ok(_movieRepository.AddMovie(MovieDto));
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = _movieRepository.GetMovies();

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("findbycountry/{country}")]
        public ActionResult<MovieDto> GetMoviesByCountry(string country)
        {
            var movies = _movieRepository.GetMoviesByCountry(country);

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("findbycountry/{country}/{territory}")]
        public ActionResult<MovieDto> GetMoviesByCountryAndTerritory(string country, string territory)
        {
            var movies = _movieRepository.GetMoviesByCountryAndTerritory(country, territory);

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovieById(int Id)
        {
            var movie = _movieRepository.GetMovieById(Id);
            
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPut("updatemovie/{id}")]
        public ActionResult<MovieDto> UpdateMovie([FromBody] MovieDto MovieDto)
        {
            return Ok(_movieRepository.UpdateMovie(MovieDto));
        } 
    }
}
