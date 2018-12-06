﻿using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class CountryController
    {
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await new CountryResource().GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryAsync(string countryCode)
        {
            return await new CountryResource().GetCountryAsync(countryCode);
        }       
    }
}
