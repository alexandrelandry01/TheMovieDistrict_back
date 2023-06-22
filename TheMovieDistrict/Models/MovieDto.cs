using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int YearOfRelease { get; set; }
        public string Director { get; set; } = null!;
        public ICollection<Location> locations { get; set; } = new List<Location>();
    }
}
