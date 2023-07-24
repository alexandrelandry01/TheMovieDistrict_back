using TheMovieDistrict.Models;

namespace TheMovieDistrict.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int YearOfRelease { get; set; }
        public string Director { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = new List<Location>();
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }

        public static Movie FromMovieDto(MovieDto MovieDto)
        {
            return new Movie
            {
                Id = MovieDto.Id,
                Title = MovieDto.Title,
                YearOfRelease = MovieDto.YearOfRelease,
                Director = MovieDto.Director,
                Locations = MovieDto.Locations,
                IsPublished = MovieDto.IsPublished,
                CreationDate = MovieDto.CreationDate
            };
        }
    }
}
