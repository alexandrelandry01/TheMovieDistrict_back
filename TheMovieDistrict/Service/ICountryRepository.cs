using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetCountries();
    }
}
