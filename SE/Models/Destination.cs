using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE.Models
{
    public class Destination
    {
        public int Id { get; set; } = default!;
        public string Geolocation { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Image { get; set; } = default!;

        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
    }
}