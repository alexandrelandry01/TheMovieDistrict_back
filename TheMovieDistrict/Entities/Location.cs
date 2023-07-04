namespace TheMovieDistrict.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string? Description { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
    }
}