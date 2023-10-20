using Microsoft.EntityFrameworkCore;
using TheMovieDistrict.Data;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service.impl
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<LocationDto>>? UpdateLocations(int Id, ICollection<LocationDto> Locations)
        {
            var movie = await _context.Movies.FindAsync(Id);

            if (movie == null)
            {
                return null!;
            }

            var movieLocations = movie.Locations;

            foreach (LocationDto movieLocation in Locations.ToList())
            {
                movieLocations.Add(Location.FromLocationDto(movieLocation));
            }

            var success = await _context.SaveChangesAsync() > 0;

            return success ? Locations : null!;
        }

        public async Task<IEnumerable<string>> GetDistinctCountries()
        {
            return await _context.Locations.Where(l => l.Address!.Country != null).Select(l => l.Address!.Country!).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctTerritories(string CountryName)
        {
            return await _context.Locations.Where(l => l.Address!.Country != null && l.Address.Country.Equals(CountryName))
                                                   .Select(l => l.Address!.Territory!).Distinct().ToListAsync();
        }

        private ICollection<LocationDto> FromLocation(ICollection<Location> Locations)
        {
            List<LocationDto> convertedList = new();
            foreach (Location location in Locations)
            {
                LocationDto dto = new LocationDto
                {
                    Id = location.Id,
                    Description = location.Description,
                    Address = location.Address,
                    Movie = location.Movie
                };
                convertedList.Add(dto);
            }
            return convertedList;
        }

        private ICollection<Location> FromLocationDto(ICollection<LocationDto> Locations)
        {
            List<Location> convertedList = new();
            foreach (LocationDto location in Locations)
            {
                Location loc = new Location
                {
                    Id = location.Id,
                    Description = location.Description,
                    Address = location.Address,
                    Movie = location.Movie
                };
                convertedList.Add(loc);
            }
            return convertedList;
        }
    }
}
