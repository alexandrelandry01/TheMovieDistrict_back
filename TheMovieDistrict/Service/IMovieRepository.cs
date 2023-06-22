using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        Movie? GetMovieById(int id);
    }
}
