using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Service;
using AutoMapper;
using TheMovieDistrict.Models;
using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository, IMapper mapper) 
        {
            _movieRepository = movieRepository ?? 
                throw new ArgumentNullException(nameof(movieRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("addmovie")]
        public ActionResult<MovieDto> AddMovie([FromBody] Movie Movie)
        {
            Movie.CreationDate = DateTime.Now;

            return Ok(_movieRepository.AddMovie(Movie));
        }

        [HttpPut("updatelocations/{id}")]
        public ActionResult<MovieDto> UpdateLocations(int id, [FromBody] ICollection<Location> Locations)
        {
            var movie = _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }
            movie.Locations = Locations;

            return Ok(_movieRepository.UpdateLocations(movie));
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            var movies =  _movieRepository.GetMovies();

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
