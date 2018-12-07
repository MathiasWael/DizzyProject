using DizzyProxy.Models;
using DizzyProxy.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxyTests
{
    [TestClass]
    public class CountryTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllCountries_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<Country> countries = new CountryResource().GetAllCountries();

            // Assert
            Assert.AreEqual(10, countries.Count);
        }

        [TestMethod]
        public void GetCountry_ValidInput_Succesful()
        {
            // Arrange
            Helpers.Login();

            // Act
            Country country = new CountryResource().GetCountry("DK");

            // Assert
            Assert.IsTrue(country.Name == "Denmark");
        }
    }
}
