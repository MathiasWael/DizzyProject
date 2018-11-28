using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.BusinessLogic
{
    public class LocationController
    {
        public Location GetLocation(long id)
        {
            return new LocationResource().GetLocation(id);
        }

        public Location CreateLocation(int zipCode, string address)
        {
            return new LocationResource().CreateLocation(zipCode, address);
        }
    }
}
