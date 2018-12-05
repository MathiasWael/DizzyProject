﻿using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class CountryRessource : Resource
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
            Request request = new Request(Method.GET, "countries/" + countryCode);
            return await ExecuteAsync<Country>(request);
        }
        
    }
}
