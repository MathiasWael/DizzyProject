using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class DizzinessTest
    {
        DizzinessResource dizzinessResource = new DizzinessResource();

        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void CreateDizziness_NoExercise_Successful() //dun work, login giver connection fejl
        {
            // Arrange
            Helpers.Login();
            int level = 7;
            string note = "Er svimmel i dag - Anna";

            // Act
            Dizziness dizziness = dizzinessResource.Submit(null, level, note);

            // Assert
            Assert.AreEqual(dizziness.Level, level);
            Assert.AreEqual(dizziness.Note, note);
        }

        [TestMethod]
        public void GetAllDizzinessesTest_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<Dizziness> dizzinesses = new DizzinessResource().GetAllDizzinesses("2018-11-28").Result;

            // Assert
            Assert.AreEqual(1, dizzinesses.Count());
        }
    }
}
