using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Service
{
    public interface IMovieRepository
    {
        Movie? AddMovie([FromBody] Movie Movie);
        Movie? UpdateLocations(Movie Movie);
        IEnumerable<Movie> GetMovies();
        Movie? GetMovieById(int id);
        bool MovieAlreadyExists(Movie Movie);
    }
}