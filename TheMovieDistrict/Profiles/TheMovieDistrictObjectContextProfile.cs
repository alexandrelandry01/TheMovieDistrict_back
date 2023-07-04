using AutoMapper;

namespace TheMovieDistrict.Profiles
{
    public class TheMovieDistrictObjectContextProfile : Profile
    {
        public TheMovieDistrictObjectContextProfile()
        {
            CreateMap<Entities.Article, Models.ArticleDto>();
            CreateMap<Entities.Movie, Models.MovieDto>();
            CreateMap<Entities.Country, Models.CountryDto>();
        }
    }
}
