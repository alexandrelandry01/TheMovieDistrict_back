using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string? Description { get; set; } = null!;
        public Address? Address { get; set; } = null!;
        public Movie? Movie { get; set; } = null!;
    }
}
