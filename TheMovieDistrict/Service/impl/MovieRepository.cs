using Microsoft.EntityFrameworkCore;
using TheMovieDistrict.Data;
using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service.impl
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Movie? AddMovie(Movie Movie)
        {
            if (!MovieAlreadyExists(Movie))
            {
                _context.Movies.Add(Movie);
                var success = _context.SaveChanges() > 0;

                return success ? Movie : null;
            }
            return null;
        }

        public Movie? UpdateLocations(Movie Movie)
        {
            _context.Movies.Update(Movie);
            var success = _context.SaveChanges() > 0;

            return success ? Movie : null;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Locations).ToList();
        }

        public Movie? GetMovieById(int id)
        {
            return _context.Movies.Where(m => m.Id == id).FirstOrDefault();
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
