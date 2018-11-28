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
        public async Task<Location> GetLocation(long id)
        {
            return await new LocationResource().GetLocationAsync(id);
        }

        public async Task<Location> CreateLocation(int zipCode, string address)
        {
            return await new LocationResource().CreateLocationAsync(zipCode, address);
        }
    }
}
