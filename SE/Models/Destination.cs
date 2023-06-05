using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; } = default!;
        public string Geolocation { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;

        [NotMapped]
        public virtual IEnumerable<UserDestination> AbsUserDestinations { get; set; } = default!;
    }
}