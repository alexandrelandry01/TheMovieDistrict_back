using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationDto>>? UpdateLocations(int Id, ICollection<LocationDto> Locations);
        Task<IEnumerable<string>> GetDistinctCountries();
        Task<IEnumerable<string>> GetDistinctTerritories(string CountryName);
    }
}