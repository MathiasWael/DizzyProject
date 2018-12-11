using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class DizzinessTests
    {
        public DizzinessResource DizzinessResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            DizzinessResource = new DizzinessResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllDizzinesses_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<Dizziness> dizzinesses = DizzinessResource.GetAllDizzinesses(Resource.UserId);

            // Assert
            Assert.AreEqual(24, dizzinesses.Count);
        }

        [TestMethod]
        public void GetAllDizzinesses_Physiotherapist_Successful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<Dizziness> dizzinesses = DizzinessResource.GetAllDizzinesses(2);

            // Assert
            Assert.AreEqual(2, dizzinesses.Count);
        }

        [TestMethod]
        public void CreateDizziness_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();
            string note = "Note";
            int? level = 7;

            // Act
            Dizziness dizziness = DizzinessResource.CreateDizziness(Resource.UserId, null, level, note);

            // Assert
            Assert.AreEqual(Resource.UserId, dizziness.PatientId);
            Assert.AreEqual(null, dizziness.ExerciseId);
            Assert.AreEqual(note, dizziness.Note);
            Assert.AreEqual(level, dizziness.Level);
        }
    }
}