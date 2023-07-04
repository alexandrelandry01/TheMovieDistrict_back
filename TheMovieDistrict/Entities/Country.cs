using System.ComponentModel.DataAnnotations.Schema;

namespace TheMovieDistrict.Entities
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
    }
}
