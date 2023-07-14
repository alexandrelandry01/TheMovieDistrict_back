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
            _context.Movies.Add(Movie);
            var success = _context.SaveChanges() > 0;

            return success ? Movie : null;
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
    }
}
