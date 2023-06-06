using System.ComponentModel.DataAnnotations;

namespace SE.DTO.Destination
{
    public class DestinationDTO
    {
        public int id { get; set; }
        [Required]
        public string Geolocation { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public bool isPrivate { get; set; }
    }
}