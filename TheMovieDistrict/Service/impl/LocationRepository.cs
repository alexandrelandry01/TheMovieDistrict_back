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

        public IEnumerable<LocationDto>? UpdateLocations(int Id, ICollection<LocationDto> Locations)
        {
            var movie = _context.Movies.Find(Id);

            if (movie == null)
            {
                return null;
            }

            var movieLocations = movie.Locations;

            foreach (LocationDto movieLocation in Locations.ToList())
            {
                movieLocations.Add(Location.FromLocationDto(movieLocation));
            }

            _context.SaveChanges();

            return Locations;
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
