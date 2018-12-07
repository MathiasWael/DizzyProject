using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class CountryController
    {
        private CountryResource _countryResource;

        public CountryController()
        {
            _countryResource = new CountryResource();
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _countryResource.GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryAsync(string countryCode)
        {
            return await _countryResource.GetCountryAsync(countryCode);
        }       
    }
}