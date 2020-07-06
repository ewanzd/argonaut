using System.ComponentModel.DataAnnotations;

namespace Argonaut.Api.Models
{
    public class PointOfInterestDto
    {
        [Required]
        public long PointOfInterestId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public CoordinateDto Coordinate { get; set; }
    }
}
