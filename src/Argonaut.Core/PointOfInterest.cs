using GeoAPI.Geometries;

namespace Argonaut.Core
{
    /// <summary>
    /// Entity
    /// </summary>
    public class PointOfInterest
    {
        public PointOfInterest(int pointOfInterestId, string name, string description, Coordinate coordinate)
        {
            PointOfInterestId = pointOfInterestId;
            Name = name;
            Description = description;
            Coordinate = coordinate;
        }

        public int PointOfInterestId { get; }

        public string Name { get; }

        public string Description { get; }

        public Coordinate Coordinate { get; }
    }
}
