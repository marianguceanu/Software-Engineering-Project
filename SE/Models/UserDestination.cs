namespace SE.Models
{
    public class UserDestination
    {
        public int UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public int DestinationId { get; set; } = default!;
        public Destination Destination { get; set; } = default!;
    }
}