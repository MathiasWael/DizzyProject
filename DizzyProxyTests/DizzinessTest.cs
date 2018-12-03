﻿using System;
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
    }
}
