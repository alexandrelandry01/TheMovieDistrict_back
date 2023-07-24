using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public Address? Address { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
        public bool IsUnknown { get; set; }
        public bool IsFictional { get; set; }

        public static LocationDto FromLocation(Location Location)
        {
            return new LocationDto
            {
                Id = Location.Id,
                Description = Location.Description!,
                Address = Location.Address,
                Movie = Location.Movie!,
                IsUnknown = Location.IsUnknown,
                IsFictional = Location.IsFictional
            };
        }
    }
}
