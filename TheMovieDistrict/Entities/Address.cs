using System.ComponentModel.DataAnnotations.Schema;
using TheMovieDistrict.Util;

namespace TheMovieDistrict.Entities
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? HouseNumber { get; set; }
        public string? StreetName { get; set; }
        public string? Coordinates { get; set; }
        public string City { get; set; } = null!;
        public Country Country { get; set; }
    }
}