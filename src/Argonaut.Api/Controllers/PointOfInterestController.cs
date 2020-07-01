using Argonaut.Api.Models;
using Argonaut.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Argonaut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;

        public PointOfInterestController(IPointOfInterestRepository pointOfInterestRepository)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
        }

        /// <summary>
        /// Get all point of interests.
        /// </summary>
        /// <returns>All point of interests.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterests()
        {
            return Ok(_pointOfInterestRepository.GetAll().Select(poi =>
                new PointOfInterestDto
                {
                    PointOfInterestId = poi.PointOfInterestId,
                    Name = poi.Name,
                    Description = poi.Description,
                    Coordinate = new CoordinateDto
                    {
                        Latitude = poi.Coordinate.X.ToString(CultureInfo.InvariantCulture),
                        Longitude = poi.Coordinate.Y.ToString(CultureInfo.InvariantCulture)
                    }
                }));
        }
    }
}
