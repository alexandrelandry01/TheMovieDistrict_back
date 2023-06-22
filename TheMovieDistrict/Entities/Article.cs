using System.ComponentModel.DataAnnotations;

namespace TheMovieDistrict.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
