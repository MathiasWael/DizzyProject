using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class CityTests
    {
        public CityResource CityResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            CityResource = new CityResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllCities_Patient_Successful()
        {
            //Arrange
            Helpers.PatientLogin();

            // Act
            List<City> cities = CityResource.GetAllCities();

            // Assert
            Assert.AreEqual(18, cities.Count);
        }

        [TestMethod]
        public void GetCity_Patient_Succesful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            City city = CityResource.GetCity("9000", "DK");

            // Assert
            Assert.AreEqual("Aalborg", city.Name);
            Assert.AreEqual("9000", city.ZipCode);
            Assert.AreEqual("DK", city.CountryCode);
        }
    }
}