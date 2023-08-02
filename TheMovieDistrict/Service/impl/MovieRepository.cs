using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMovieDistrict.Data;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service.impl
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public MovieDto? AddMovie(MovieDto MovieDto)
        {
            Movie Movie = Movie.FromMovieDto(MovieDto);

            if (!MovieAlreadyExists(Movie))
            {
                _context.Movies.Add(Movie);
                var success = _context.SaveChanges() > 0;

                return success ? MovieDto.FromMovie(Movie) : null;
            }
            return null;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Locations).ToList();
        }

        public MovieDto? GetMovieById(int Id)
        {
            var movie = _context.Movies.Where(m => m.Id == Id)
                                  .Include(m => m.Locations)
                                  .ThenInclude(l => l.Address)
                                  .FirstOrDefault();

            if (movie == null)
            {
                return null;
            }

            return MovieDto.FromMovie(movie);
        }

        public MovieDto? UpdateMovie([FromBody] MovieDto MovieDto)
        {
            var movie = _context.Movies.Find(MovieDto.Id);

            if (movie != null)
            {
                _context.Entry(movie).CurrentValues.SetValues(MovieDto);
            }

            bool success = _context.SaveChanges() > 0;

            return success ? MovieDto : null;
        }

        public bool MovieAlreadyExists(Movie Movie)
        {
            var result = _context.Movies.Where(m => m.Title == Movie.Title)
                                        .Where(m => m.YearOfRelease == Movie.YearOfRelease)
                                        .Where(m => m.Director == Movie.Director)
                                        .FirstOrDefault();
            return result != null;
        }
    }
}
