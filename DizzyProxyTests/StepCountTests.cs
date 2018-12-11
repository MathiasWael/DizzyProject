﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class StepCountTests
    {
        public StepCountResource StepCountResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            StepCountResource = new StepCountResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllStepCounts_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<StepCount> stepCounts = StepCountResource.GetAllStepCounts(Resource.UserId);

            // Assert
            Assert.AreEqual(43, stepCounts.Count());
        }

        [TestMethod]
        public void GetAllStepCounts_Physiotherapist_Successful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<StepCount> stepCounts = StepCountResource.GetAllStepCounts(2);

            // Assert
            Assert.AreEqual(2, stepCounts.Count());
        }
    }
}