using System.ComponentModel.DataAnnotations;

namespace SE.DTO.Destination
{
    public class DestinationDTO
    {
        [Required]
        public string Geolocation { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; } = default!;
        [Required]
        public DateTime EndDate { get; set; } = default!;
    }
}