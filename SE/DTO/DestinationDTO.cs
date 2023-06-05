using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE.DTO
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