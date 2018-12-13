using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;

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

        [TestMethod]
        public void CreateStepCount_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();
            long patientId = 1;
            int count = 4215;
            DateTime dateTime = new DateTime(2018, 12, 05);

            // Act
            StepCount stepCount = StepCountResource.CreateStepCount(patientId, count, dateTime);

            // Assert
            Assert.AreEqual(patientId, stepCount.PatientId);
            Assert.AreEqual(count, stepCount.Count);
            Assert.AreEqual(47, stepCount.Id);
        }

        [TestMethod]
        public void UpdateStepCount_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();
            StepCount stepCount = StepCountResource.CreateStepCount(1, 3652, new DateTime(2018, 12, 05));
            stepCount.Count = 4215;

            // Act
            stepCount = StepCountResource.UpdateStepCount(stepCount);

            // Assert
            Assert.AreEqual(4215, stepCount.Count);
            Assert.AreEqual(47, stepCount.Id);
        }
    }
}