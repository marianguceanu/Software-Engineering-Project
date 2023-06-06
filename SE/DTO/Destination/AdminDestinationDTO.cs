using System.ComponentModel.DataAnnotations;

namespace SE.DTO.User
{
    public class AdminDestinationDTO
    {
        public int id { get; set; }
        [Required]
        public string Geolocation { get; set; } = default!;
        [Required]
        public string Title { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!;
        [Required]
        public string Image { get; set; } = default!;
        [Required]
        public DateTime StartDate { get; set; } = default!;
        [Required]
        public DateTime EndDate { get; set; } = default!;
    }
}