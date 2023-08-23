using System.ComponentModel.DataAnnotations;

namespace TheMovieDistrict.Models
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}