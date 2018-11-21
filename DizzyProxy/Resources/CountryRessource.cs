using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class CountryRessource
    {
        public List<Country> GetAllCountries() 
        {
            return new List<Country>()
            {
                new Country() {Id = 1, Name = "Denmark", Code = "DK"},
                new Country() {Id = 2, Name = "England", Code = "EN"},
                new Country() {Id = 3, Name = "Japan", Code = "JP"},
            };
        }
    }
}
