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
    public class CityTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllCities_Successful()
        {
            //Arrange
            Helpers.Login();

            // Act
            List<City> allCities = new CityResource().GetAllCities();

            // Assert
            Assert.AreEqual(17, allCities.Count);
        }

        [TestMethod]
        public void GetCity_ValidInput_Succesful()
        {
            // Arrange
            Helpers.Login();

            // Act
            City city = new CityResource().GetCity("9000", "DK");

            // Assert
            Assert.IsTrue(city.Name == "Aalborg");
        }
    }
}
