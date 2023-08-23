using Microsoft.AspNetCore.Identity;

namespace TheMovieDistrict.Roles
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; } = null!;
    }
}