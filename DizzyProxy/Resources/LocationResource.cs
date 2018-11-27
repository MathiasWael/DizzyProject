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
        public async Task<Location> CreateLocationAsync(int zipCode, string address)
        {
            Request request = new Request(Method.POST, "locations");
            request.Body["zip_code"] = zipCode;
            request.Body["address"] = address;
            return await ExecuteAsync<Location>(request);
        }

        public async Task<Location> GetLocationAsync(long id)
        {
            Request request = new Request(Method.GET, $"locations/{id}");
            return await ExecuteAsync<Location>(request);
        }
    }
}
