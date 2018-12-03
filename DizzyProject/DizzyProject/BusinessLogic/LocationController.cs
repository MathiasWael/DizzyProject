using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class LocationController
    {
        public async Task<Location> GetLocationAsync(long? id)
        {
            return await new LocationResource().GetLocationAsync(id);
        }

        public async Task<Location> CreateLocationAsync(int zipCode, string address)
        {
            return await new LocationResource().CreateLocationAsync(zipCode, address);
        }

        public async Task<Location> updateLocation(Location location)
        {
            return await new LocationResource().UpdateLocationAsync(location);
        }
    }
}
