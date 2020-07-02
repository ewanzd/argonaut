using System.ComponentModel.DataAnnotations;

namespace Argonaut.Api.Models
{
    public class CoordinateDto
    {
        [Required]
        [Range(-90, 90)]
        public decimal Latitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Longitude { get; set; }
    }
}
