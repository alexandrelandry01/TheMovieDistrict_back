namespace TheMovieDistrict.Models
{
    public class UserDto
    {
        public string UserName { get; set; } = null!;
        public string Token { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
