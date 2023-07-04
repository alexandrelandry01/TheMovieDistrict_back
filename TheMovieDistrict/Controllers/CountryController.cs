using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Models;
using TheMovieDistrict.Service;

namespace TheMovieDistrict.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository ??
                throw new ArgumentNullException(nameof(countryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<CountryDto> GetCountries()
        {
            var countries = _countryRepository.GetCountries();

            if (countries == null)
            {
                return NotFound();
            }
            return Ok(countries);
        }
    }
}
