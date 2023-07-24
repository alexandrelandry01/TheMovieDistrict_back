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

        [HttpPost("updatelocations/{id}")]
        public ActionResult<IEnumerable<LocationDto>> UpdateLocations(int Id, [FromBody] ICollection<LocationDto> Locations)
        {
            var locations = _locationRepository.UpdateLocations(Id, Locations);

            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }
    }
}
