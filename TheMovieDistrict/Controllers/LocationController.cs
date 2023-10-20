using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheMovieDistrict.Models;
using TheMovieDistrict.Service;

namespace TheMovieDistrict.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository ??
                throw new ArgumentNullException(nameof(locationRepository));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatelocations/{id}")]
        public async Task<ActionResult<IEnumerable<LocationDto>>> UpdateLocations(int Id, [FromBody] ICollection<LocationDto> Locations)
        {
            var locations = await _locationRepository.UpdateLocations(Id, Locations)!;

            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<string>>> GetDistinctCountries()
        {
            return Ok(await _locationRepository.GetDistinctCountries());
        }

        [HttpGet("{country}")]
        public async Task<ActionResult<IEnumerable<string>>> GetDistinctCountries(string Country)
        {
            return Ok(await _locationRepository.GetDistinctTerritories(Country));
        }
    }
}
