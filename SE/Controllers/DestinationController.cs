using SE.Models;

namespace SE.Controllers
{
    public class DestinationController
    {
        private User User { get; set; } = default!;
        public ICollection<Destination> Destinations { get; set; } = default!;
        public DestinationController(User user) { User = user; }
    }
}