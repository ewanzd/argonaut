using NetTopologySuite.Geometries;

namespace Argonaut.Persistence.Models
{
    public class PointOfInterestDal
    {
        public int PointOfInterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Point Coordinate { get; set; }
    }
}
