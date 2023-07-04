using TheMovieDistrict.Data;
using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service.impl
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}
