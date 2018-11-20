using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.BusinessLogic
{
    public class CountryController
    {
        CountryRessource countryRessource;

        public List<Country> getAllCountries()
        {
            countryRessource = new CountryRessource();
            return countryRessource.GetAllCountries();
        }
    }
}
