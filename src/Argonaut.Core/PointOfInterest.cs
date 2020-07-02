using System;

namespace Argonaut.Core
{
    /// <summary>
    /// Entity
    /// </summary>
    public class PointOfInterest
    {
        public PointOfInterest(string name, string description, Coordinate coordinate) : this(0, name, description, coordinate)
        {

        }

        public PointOfInterest(int id, string name, string description, Coordinate coordinate)
        {
            PointOfInterestId = id;
            Name = name;
            Description = description;
            Coordinate = coordinate;
        }

        public int PointOfInterestId { get; private set; }

        public string Name { get; }

        public string Description { get; }

        public Coordinate Coordinate { get; }

        public void SetId(int id)
        {
            if (PointOfInterestId != 0)
            {
                throw new InvalidOperationException("id is already set.");
            }

            PointOfInterestId = id;
        }
    }
}
