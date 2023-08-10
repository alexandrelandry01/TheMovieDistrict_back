using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Entities;
using TheMovieDistrict.Models;

namespace TheMovieDistrict.Service
{
    public interface IMovieRepository
    {
        Task<MovieDto>? AddMovie([FromBody] MovieDto MovieDto);
        Task<IEnumerable<MovieDto>>? GetMovies();
        Task<IEnumerable<MovieDto>>? GetMoviesByCountry(string country);
        Task<IEnumerable<MovieDto>>? GetMoviesByCountryAndTerritory(string country, string territory);
        Task<MovieDto>? GetMovieById(int Id);
        Task<IEnumerable<MovieDto>>? GetLatestMovies();
        Task<IEnumerable<MovieDto>>? GetSearchResults(string param);
        Task<MovieDto>? UpdateMovie([FromBody] MovieDto MovieDto);
        Task<bool> MovieAlreadyExists(Movie Movie);
    }
}