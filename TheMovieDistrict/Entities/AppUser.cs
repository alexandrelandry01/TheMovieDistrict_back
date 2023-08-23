using Microsoft.AspNetCore.Identity;
using TheMovieDistrict.Roles;

namespace TheMovieDistrict.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; } = null!;
    }
}