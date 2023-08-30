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

        public async Task<MovieDto>? AddMovie(MovieDto MovieDto)
        {
            Movie Movie = Movie.FromMovieDto(MovieDto);

            if (!(await MovieAlreadyExists(Movie))!)
            {
                _context.Movies.Add(Movie);
                var success = await _context.SaveChangesAsync() > 0;

                return success ? MovieDto.FromMovie(Movie) : null!;
            }
            return null!;
        }

        public async Task<IEnumerable<MovieDto>>? GetMovies()
        {
            var movies = await _context.Movies.OrderBy(m => m.Title).Include(m => m.Locations).ToListAsync();

            ICollection<MovieDto> resultMapped = new List<MovieDto>();

            if (movies.Any())
            {
                foreach (Movie Movie in movies.ToList())
                {
                    resultMapped.Add(MovieDto.FromMovie(Movie));
                }
            }
            return resultMapped;
        }

        public async Task<IEnumerable<MovieDto>>? GetMoviesByCountry(string country)
        {
            var movies = await _context.Movies.Where(m => m.Locations.Any(l => l.Address!.Country!.Equals(country))).ToListAsync();

            ICollection<MovieDto> resultMapped = new List<MovieDto>();

            if (movies.Any())
            {
                foreach (Movie Movie in movies.ToList())
                {
                    resultMapped.Add(MovieDto.FromMovie(Movie));
                }
            }
            return resultMapped;
        }

        public async Task<IEnumerable<MovieDto>>? GetMoviesByCountryAndTerritory(string country, string territory)
        {
            var movies = await _context.Movies.Where(m => m.Locations.Any(l => l.Address!.Country!.Equals(country)
                                               && l.Address!.Territory!.Equals(territory))).ToListAsync();

            ICollection<MovieDto> resultMapped = new List<MovieDto>();

            if (movies.Any())
            {
                foreach (Movie Movie in movies.ToList())
                {
                    resultMapped.Add(MovieDto.FromMovie(Movie));
                }
            }
            return resultMapped;
        }

        public async Task<MovieDto>? GetMovieById(int Id)
        {
            var movie = await _context.Movies.Where(m => m.Id == Id)
                                       .Include(m => m.Locations)
                                       .ThenInclude(l => l.Address)
                                       .FirstOrDefaultAsync();

            if (movie == null)
            {
                return null!;
            }

            return MovieDto.FromMovie(movie);
        }

        public async Task<IEnumerable<MovieDto>>? GetLatestMovies()
        {
            var movies = await _context.Movies.Where(m => m.IsPublished).OrderByDescending(m => m.CreationDate).Take(5).ToListAsync();

            ICollection<MovieDto> resultMapped = new List<MovieDto>();

            if (movies.Any())
            {
                foreach (Movie Movie in movies.ToList())
                {
                    resultMapped.Add(MovieDto.FromMovie(Movie));
                }
            }
            return resultMapped;
        }

        public async Task<IEnumerable<MovieDto>>? GetSearchResults(string param)
        {
            var movies = await _context.Movies.Where(m => m.Title.Contains(param)
                                               || m.Locations.Any(l => l.Description.Contains(param))).ToListAsync();

            ICollection<MovieDto> resultMapped = new List<MovieDto>();

            if (movies.Any())
            {
                foreach (Movie Movie in movies.ToList())
                {
                    resultMapped.Add(MovieDto.FromMovie(Movie));
                }
            }
            return resultMapped;
        }

        public async Task<MovieDto>? UpdateMovie([FromBody] MovieDto MovieDto)
        {
            var movie = await _context.Movies.FindAsync(MovieDto.Id);

            if (movie != null)
            {
                _context.Entry(movie).CurrentValues.SetValues(MovieDto);
            }

            bool success = await _context.SaveChangesAsync() > 0;

            return success ? MovieDto : null!;
        }

        public async Task<bool> MovieAlreadyExists(Movie Movie)
        {
            var result = await _context.Movies.Where(m => m.Title == Movie.Title)
                                        .Where(m => m.YearOfRelease == Movie.YearOfRelease)
                                        .Where(m => m.Director == Movie.Director)
                                        .FirstOrDefaultAsync();
            return result != null;
        }
    }
}
