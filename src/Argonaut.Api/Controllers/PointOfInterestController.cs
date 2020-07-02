using System;
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
        public ActionResult<PointOfInterestDto> PostPointOfInterest(PointOfInterestCreateDto pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var latitude = (double)pointOfInterest.Coordinate.Latitude;
            var longitude = (double)pointOfInterest.Coordinate.Longitude;

            var newPoi = new PointOfInterest(pointOfInterest.Name, pointOfInterest.Description, new Coordinate(latitude, longitude));

            _pointOfInterestRepository.Add(newPoi);
            _pointOfInterestRepository.Save();

            return Ok( new PointOfInterestDto
                {
                    PointOfInterestId = newPoi.PointOfInterestId,
                    Name = newPoi.Name,
                    Description = newPoi.Description,
                    Coordinate = new CoordinateDto
                    {
                        Latitude = (decimal)newPoi.Coordinate.Latitude,
                        Longitude = (decimal)newPoi.Coordinate.Longitude
                    }
                });
        }
    }
}
