using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Models
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int? HouseNumber { get; set; }
        public string? StreetName { get; set; }
        public string? Coordinates { get; set; }
        public string City { get; set; } = null!;
        public string? Territory { get; set; } = null!;
        public Country? Country { get; set; } = null!;
    }
}
