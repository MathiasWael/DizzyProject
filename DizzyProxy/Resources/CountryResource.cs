using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class CountryResource : Resource
    {
        public List<Country> GetAllCountries()
            => GetAllCountriesAsync().Result;

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            Request request = new Request(Method.GET, "countries");
            return await ExecuteAsync<List<Country>>(request);
        }

        public Country GetCountry(string countryCode)
            => GetCountryAsync(countryCode).Result;

        public async Task<Country> GetCountryAsync(string countryCode)
        {
            Request request = new Request(Method.GET, $"countries/{countryCode}");
            return await ExecuteAsync<Country>(request);
        }
    }
}