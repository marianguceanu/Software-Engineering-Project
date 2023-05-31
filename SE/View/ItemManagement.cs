using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE.Controllers;
using SE.Models;

namespace SE.View
{
    public class ItemManagement
    {
        DestinationController dc = default!;

        public void DisplayItems(ICollection<Destination> destinations) { }

        public void DisplayPublicDestinations()
        {
            DisplayItems(dc.Destinations);
        }


    }
}