using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class CityController
    {
        private CityResource _cityResource;

        public CityController()
        {
            _cityResource = new CityResource();
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _cityResource.GetAllCitiesAsync();
        }

        public async Task<City> GetCityAsync(string zipCode, string countryCode)
        {
            return await _cityResource.GetCityAsync(zipCode, countryCode);
        }
    }
}