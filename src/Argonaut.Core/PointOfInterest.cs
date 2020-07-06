using System;

namespace Argonaut.Core
{
    /// <summary>
    /// Immutable entity
    /// </summary>
    public class PointOfInterest
    {
        public PointOfInterest(string name, string description, Coordinate coordinate) : this(0, name, description, coordinate)
        {

        }

        public PointOfInterest(long id, string name, string description, Coordinate coordinate)
        {
            PointOfInterestId = id;
            Name = name;
            Description = description;
            Coordinate = coordinate;
        }

        public long PointOfInterestId { get; }

        public string Name { get; }

        public string Description { get; }

        public Coordinate Coordinate { get; }

        public PointOfInterest SetId(long id)
        {
            if (PointOfInterestId != 0)
            {
                throw new InvalidOperationException("id is already set.");
            }

            return new PointOfInterest(id, Name, Description, Coordinate);
        }
    }
}
