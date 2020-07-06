using Argonaut.Api.Models;
using Argonaut.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Argonaut.Api.Controllers
{
    [Route("pois")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly IPointOfInterestService _pointOfInterestService;

        public PointOfInterestController(IPointOfInterestService pointOfInterestService)
        {
            _pointOfInterestService = pointOfInterestService;
        }

        /// <summary>
        /// Get all point of interests.
        /// </summary>
        /// <returns>All point of interests.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterests()
        {
            return Ok(_pointOfInterestService.GetAllPointOfInterests().Select(poi =>
                new PointOfInterestDto
                {
                    PointOfInterestId = poi.PointOfInterestId,
                    Name = poi.Name,
                    Description = poi.Description,
                    Coordinate = new CoordinateDto
                    {
                        Latitude = (decimal)poi.Coordinate.Latitude,
                        Longitude = (decimal)poi.Coordinate.Longitude
                    }
                }));
        }

        /// <summary>
        /// Create new point of interest.
        /// </summary>
        /// <param name="pointOfInterest">New point of interest.</param>
        /// <returns>New point of interest with id.</returns>
        [HttpPost]
        public ActionResult<PointOfInterestDto> PostPointOfInterest(CreatePointOfInterestDto pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var latitude = (double)pointOfInterest.Coordinate.Latitude;
            var longitude = (double)pointOfInterest.Coordinate.Longitude;

            var newPoi = new PointOfInterest(pointOfInterest.Name, pointOfInterest.Description, new Coordinate(latitude, longitude));

            var savedPoi = _pointOfInterestService.CreatePointOfInterest(newPoi);

            return Ok(new PointOfInterestDto
                {
                    PointOfInterestId = savedPoi.PointOfInterestId,
                    Name = savedPoi.Name,
                    Description = savedPoi.Description,
                    Coordinate = new CoordinateDto
                    {
                        Latitude = (decimal)savedPoi.Coordinate.Latitude,
                        Longitude = (decimal)savedPoi.Coordinate.Longitude
                    }
                });
        }
    }
}
