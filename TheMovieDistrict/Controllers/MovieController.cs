using TheMovieDistrict.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TheMovieDistrict.Entities;
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

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            var movies =  _movieRepository.GetMovies();

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
