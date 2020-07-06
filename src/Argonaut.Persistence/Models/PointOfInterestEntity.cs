using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Argonaut.Persistence.Models
{
    [Table("pointOfInterests")]
    public class PointOfInterestEntity
    {
        [Key]
        public long PointOfInterestId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Point Coordinate { get; set; }
    }
}
