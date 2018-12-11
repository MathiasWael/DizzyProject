using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class PhysiotherapistTests
    {
        public PhysiotherapistResource PhysiotherapistResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            PhysiotherapistResource = new PhysiotherapistResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllPhysiotherapists_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<Physiotherapist> physiotherapists = PhysiotherapistResource.GetAllPhysiotherapists();

            // Assert
            Assert.AreEqual(2, physiotherapists.Count);
        }

        [TestMethod]
        public void GetPhysiotherapist_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            Physiotherapist physiotherapist = PhysiotherapistResource.GetPhysiotherapist(6);

            // Assert
            Assert.AreEqual(6, physiotherapist.Id);
            Assert.AreEqual("Hans", physiotherapist.FirstName);
            Assert.AreEqual("Petersen", physiotherapist.LastName);
            Assert.AreEqual("hanspetersen@gmail.com", physiotherapist.Email);
            Assert.AreEqual(1, physiotherapist.OrganisationId);
        }
    }
}