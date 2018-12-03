using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class LocationResource : Resource
    {
        public Location CreateLocation(int zipCode, string address) 
            => CreateLocationAsync(zipCode, address).Result;

        public async Task<Location> CreateLocationAsync(int zipCode, string address)
        {
            Request request = new Request(Method.POST, "locations");
            request.Body["zip_code"] = zipCode;
            request.Body["address"] = address;
            return await ExecuteAsync<Location>(request);
        }

        public Location GetLocation(long? id) 
            => GetLocationAsync(id).Result;

        public async Task<Location> GetLocationAsync(long? id)
        {
            Request request = new Request(Method.GET, $"locations/{id}");
            return await ExecuteAsync<Location>(request);
        }

        public Location UpdateLocation(Location location)
            => UpdateLocationAsync(location).Result;

        public async Task<Location> UpdateLocationAsync(Location location)
        {
            Request request = new Request(Method.PUT, "locations");
            request.Body["zip_code"] = location.ZipCode;
            request.Body["address"] = location.Address;
            return await ExecuteAsync<Location>(request);
        }
    }
}
