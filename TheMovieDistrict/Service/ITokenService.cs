using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser User);
    }
}
