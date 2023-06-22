using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel;

namespace TheMovieDistrict.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int YearOfRelease { get; set; }
        public string Director { get; set; } = null!;
        public ICollection<Location> locations { get; set; } = new List<Location>();
        [DefaultValue("false")]
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
