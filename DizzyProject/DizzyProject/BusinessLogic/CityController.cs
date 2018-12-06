using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class CityController
    {
        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await new CityResource().GetAllCitiesAsync();
        }

        public async Task<City> GetCityAsync(string zipCode, string countryCode)
        {
            return await new CityResource().GetCityAsync(zipCode, countryCode);
        }

    }
}
