using AutoMapper;
using TheMovieDistrict.Entities;

namespace TheMovieDistrict.Profiles
{
    public class TheMovieDistrictObjectContextProfile : Profile
    {
        public TheMovieDistrictObjectContextProfile()
        {
            CreateMap<Entities.Article, Models.ArticleDto>();
            CreateMap<Entities.Country, Models.CountryDto>();
            CreateMap<Entities.Location, Models.LocationDto>();
            CreateMap<Entities.Movie, Models.MovieDto>();
            CreateMap<Entities.Country, Models.CountryDto>();
        }
    }
}
