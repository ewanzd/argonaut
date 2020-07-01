namespace Argonaut.Api.Models
{
    public class PointOfInterestDto
    {
        public int PointOfInterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CoordinateDto Coordinate { get; set; }
    }
}
