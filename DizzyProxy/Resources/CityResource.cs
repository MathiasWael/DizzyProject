using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class CityResource : Resource
    {
        public City GetCity(string zipCode, string countryCode)
            => GetCityAsync(zipCode, countryCode).Result;

        public async Task<City> GetCityAsync(string zipCode, string countryCode)
        {
            Request request = new Request(Method.GET, "cities/" + countryCode + "/" + zipCode);
            return await ExecuteAsync<City>(request);
        }

        public List<City> GetAllCities()
            => GetAllCitiesAsync().Result;

        public async Task<List<City>> GetAllCitiesAsync()
        {
            Request request = new Request(Method.GET, "cities");
            return await ExecuteAsync<List<City>>(request);
        }
    }
}
