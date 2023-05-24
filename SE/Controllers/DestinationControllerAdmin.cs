using SE.Models;

namespace SE.Controllers
{
    public class DestinationControllerAdmin : DestinationController
    {
        public DestinationControllerAdmin(User user) : base(user)
        {
            if (user.Type != "admin")
                throw new Exception("User is not an admin user");
        }

        public void AddDestination(Destination destination)
        {
            this.Destinations.Add(destination);
        }

        public void RemoveDestination(Destination destination)
        {
            this.Destinations.Remove(destination);
        }

        public void ModifyDestination(int DestinationId)
        {
            var Dest = this.Destinations.FirstOrDefault(d => d.Id == DestinationId);
            if (Dest == null)
                throw new Exception("Destination not found");
            this.Destinations.Remove(Dest);
        }
    }
}