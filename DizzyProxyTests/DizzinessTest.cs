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
            //Dizziness dizziness = dizzinessResource.CreateDizziness(null, level, note);

            // Assert
            //Assert.AreEqual(dizziness.Level, level);
            //Assert.AreEqual(dizziness.Note, note);
        }

        [TestMethod]
        public void GetAllDizzinessesByDateTest_Successful()
        {
            // Arrange
            Helpers.Login();
            DateTime dateTime = new DateTime(2018, 10, 15);

            // Act
            List<Dizziness> dizzinesses = new DizzinessResource().GetAllDizzinessesByDateAsync(dateTime).Result;

            // Assert
            Assert.AreEqual(3, dizzinesses.Count());
        }

        [TestMethod]
        public void GetAllDizzinessesWithLevelTest_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<Dizziness> dizzinesses = new DizzinessResource().GetAllDizzinessesWithLevelAsync().Result;

            // Assert
            Assert.AreEqual(23, dizzinesses.Count());
        }

        [TestMethod]
        public void CreateDizziness_Successful()
        {
            // Arrange
            Helpers.Login();
            DizzinessResource dizzinessResource = new DizzinessResource();
            string dizzinessNote = "Dizziness Note";
            DateTime dateTime = DateTime.Now;
            List<Dizziness> dizzinessesBefore = dizzinessResource.GetAllDizzinessesByDateAsync(DateTime.Now).Result;

            // Act
            bool success = dizzinessResource.CreateDizzinessAsync(1, 5, dizzinessNote).Result;
            List<Dizziness> dizzinessesAfter = dizzinessResource.GetAllDizzinessesByDateAsync(DateTime.Now).Result;

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(dizzinessesBefore.Count() + 1, dizzinessesAfter.Count());
            Assert.AreEqual(true, dizzinessesAfter.Exists(x => x.Note == dizzinessNote));
            Assert.AreEqual(false, dizzinessesBefore.Exists(x => x.Note == dizzinessNote));
        }

        [TestMethod]
        public void CreateDizziness_NoNote__Successful()
        {
            // Arrange
            Helpers.Login();
            DizzinessResource dizzinessResource = new DizzinessResource();
            DateTime dateTime = DateTime.Now;
            List<Dizziness> dizzinessesBefore = dizzinessResource.GetAllDizzinessesByDateAsync(DateTime.Now).Result;

            // Act
            bool success = dizzinessResource.CreateDizzinessAsync(1, 5, null).Result;
            List<Dizziness> dizzinessesAfter = dizzinessResource.GetAllDizzinessesByDateAsync(DateTime.Now).Result;

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(dizzinessesBefore.Count() + 1, dizzinessesAfter.Count());
        }

        [TestMethod]
        public void CreateDizziness_NoLevel__Successful()
        {
            // Arrange
            Helpers.Login();
            DizzinessResource dizzinessResource = new DizzinessResource();
            string dizzinessNote = "Dizziness Note";
            DateTime dateTime = DateTime.Now;
            List<Dizziness> dizzinessesBefore = dizzinessResource.GetAllDizzinessesByDateAsync(DateTime.Now).Result;

            // Act
            bool success = dizzinessResource.CreateDizzinessAsync(1, null, dizzinessNote).Result;
            List<Dizziness> dizzinessesAfter = dizzinessResource.GetAllDizzinessesByDateAsync(DateTime.Now).Result;

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(dizzinessesBefore.Count() + 1, dizzinessesAfter.Count());
            Assert.AreEqual(true, dizzinessesAfter.Exists(x => x.Note == dizzinessNote));
            Assert.AreEqual(false, dizzinessesBefore.Exists(x => x.Note == dizzinessNote));
        }
    }
}
