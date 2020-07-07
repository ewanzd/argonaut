using Argonaut.Core;
using Argonaut.Persistence.Models;
using NetTopologySuite.Geometries;
using System.Linq;

namespace Argonaut.Persistence
{
    public class PointOfInterestRepository : IPointOfInterestRepository
    {
        private readonly ArgonautContext _context;

        public PointOfInterestRepository(ArgonautContext context)
        {
            _context = context;
        }

        public IQueryable<PointOfInterest> GetAll()
        {
            return 
                from poi in _context.PointOfInterests
                select new PointOfInterest(poi.PointOfInterestId, poi.Name, poi.Description, new Coordinate(poi.Coordinate.X, poi.Coordinate.Y));
        }

        public PointOfInterest Add(PointOfInterest pointOfInterest)
        {
            var poiEntity = new PointOfInterestEntity
            {
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
                Coordinate = new Point(pointOfInterest.Coordinate.Latitude, pointOfInterest.Coordinate.Longitude)
            };
            _context.PointOfInterests.Add(poiEntity);

            return pointOfInterest.SetId(poiEntity.PointOfInterestId);
        }
    }
}
