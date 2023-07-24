using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int YearOfRelease { get; set; }
        public string Director { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = new List<Location>();
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }

        public static MovieDto FromMovie(Movie Movie)
        {
            return new MovieDto
            {
                Id = Movie.Id,
                Title = Movie.Title,
                YearOfRelease = Movie.YearOfRelease,
                Director = Movie.Director,
                Locations = Movie.Locations,
                IsPublished = Movie.IsPublished,
                CreationDate = Movie.CreationDate
            };
        }
    }
}
