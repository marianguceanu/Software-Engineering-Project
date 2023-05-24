using System.Globalization;
using SE.Models;
using SE.View;

namespace SE.Controllers
{
    public class DestinationControllerUser : DestinationController
    {
        private ICollection<Destination> UserDestinations = default!;
        ItemManagement im = new ItemManagement();
        public DestinationControllerUser(User user) : base(user)
        {
            if (user.Type != "normal")
                throw new Exception("User is not a normal user");


        }

        public void AddPublicDestination(int PublicDestId) { }
        public void AddPrivateDestination(int PrivateDestId) { }
        public void RemoveDestination(int DestId) { }
        public void ModifyDestination(int DestId) { }
    }
}