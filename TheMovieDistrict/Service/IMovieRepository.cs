using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service
{
    public interface IMovieRepository
    {
        MovieDto? AddMovie([FromBody] MovieDto MovieDto);
        IEnumerable<MovieDto>? GetMovies();
        IEnumerable<MovieDto>? GetMoviesByCountry(string country);
        IEnumerable<MovieDto>? GetMoviesByCountryAndTerritory(string country, string territory);
        MovieDto? GetMovieById(int Id);
        IEnumerable<MovieDto>? GetLatestMovies();
        IEnumerable<MovieDto>? GetSearchResults(string param);
        MovieDto? UpdateMovie([FromBody] MovieDto MovieDto);
        bool MovieAlreadyExists(Movie Movie);
    }
}