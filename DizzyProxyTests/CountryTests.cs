using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class CountryTests
    {
        public CountryResource CountryResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            CountryResource = new CountryResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllCountries_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<Country> countries = CountryResource.GetAllCountries();

            // Assert
            Assert.AreEqual(11, countries.Count);
        }

        [TestMethod]
        public void GetCountry_Patient_Succesful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            Country country = new CountryResource().GetCountry("DK");

            // Assert
            Assert.AreEqual("Denmark", country.Name);
            Assert.AreEqual("DK", country.Code);
        }
    }
}