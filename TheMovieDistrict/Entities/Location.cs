using TheMovieDistrict.Models;

namespace TheMovieDistrict.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public Address? Address { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
        public bool IsUnknown { get; set; }
        public bool IsFictional { get; set; }
        public string? Note { get; set; }
        public static Location FromLocationDto(LocationDto LocationDto)
        {
            return new Location
            {
                Id = LocationDto.Id,
                Description = LocationDto.Description!,
                Address = LocationDto.Address,
                Movie = LocationDto.Movie!,
                IsUnknown = LocationDto.IsUnknown,
                IsFictional = LocationDto.IsFictional,
                Note = LocationDto.Note
            };
        }
    }
}