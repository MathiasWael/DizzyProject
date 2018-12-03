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
    public class StepCountTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllStepCounts_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<StepCount> stepCounts = new StepCountResource().GetAllStepCountsAsync().Result;

            // Assert
            Assert.AreEqual(43, stepCounts.Count());
        }
    }
}
