using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Service;
using AutoMapper;
using TheMovieDistrict.Models;

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
        public ActionResult<MovieDto> AddMovie([FromBody] MovieDto MovieDto)
        {
            MovieDto.CreationDate = DateTime.Now;

            return Ok(_movieRepository.AddMovie(MovieDto));
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
