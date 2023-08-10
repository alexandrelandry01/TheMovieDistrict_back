using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationDto>>? UpdateLocations(int Id, ICollection<LocationDto> Locations);
    }
}