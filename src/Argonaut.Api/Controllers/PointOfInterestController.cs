using Argonaut.Api.Models;
using Argonaut.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Argonaut.Services;
using Microsoft.AspNetCore.Http;

namespace Argonaut.Api.Controllers
{
    [Route("pointOfInterests")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<PointOfInterestDto> GetPointOfInterests()
        {
            return _pointOfInterestService.GetAllPointOfInterests().Select(ConvertToDto);
        }

        /// <summary>
        /// Get all point of interests.
        /// </summary>
        /// <returns>All point of interests.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PointOfInterestDto> GetPointOfInterestById(long id)
        {
            var pointOfInterest = _pointOfInterestService.GetPointOfInterestById(id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(ConvertToDto(pointOfInterest));
        }

        /// <summary>
        /// Create new point of interest.
        /// </summary>
        /// <param name="pointOfInterest">New point of interest.</param>
        /// <returns>New point of interest with id.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PointOfInterestDto> PostPointOfInterest(CreatePointOfInterestDto pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newPoi = ConvertToEntity(pointOfInterest);
            var savedPoi = _pointOfInterestService.CreatePointOfInterest(newPoi);
            var savedPoiDto = ConvertToDto(savedPoi);

            return CreatedAtAction(nameof(GetPointOfInterestById),
                new { id = savedPoiDto.PointOfInterestId },
                savedPoiDto);
        }

        private static PointOfInterestDto ConvertToDto(PointOfInterest pointOfInterest)
        {
            return new PointOfInterestDto
            {
                PointOfInterestId = pointOfInterest.PointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
                Coordinate = new CoordinateDto
                {
                    Latitude = (decimal) pointOfInterest.Coordinate.Latitude,
                    Longitude = (decimal) pointOfInterest.Coordinate.Longitude
                }
            };
        }

        private static PointOfInterest ConvertToEntity(CreatePointOfInterestDto pointOfInterest)
        {
            var latitude = (double)pointOfInterest.Coordinate.Latitude;
            var longitude = (double)pointOfInterest.Coordinate.Longitude;

            return new PointOfInterest(
                pointOfInterest.Name, 
                pointOfInterest.Description, 
                new Coordinate(latitude, longitude));
        }
    }
}
