using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service
{
    public interface IMovieRepository
    {
        MovieDto? AddMovie([FromBody] MovieDto MovieDto);
        IEnumerable<Movie> GetMovies();
        MovieDto? GetMovieById(int Id);
        bool MovieAlreadyExists(Movie Movie);
    }
}