using System;
using DizzyProxy.Resources;
using DizzyProxy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        public void CreatePatient()
        {
            // Arrange
            PatientResource patients = new PatientResource();

            // Act
            Patient patient = patients.CreatePatient("Lars", "Larsen", "lars1@gmail.com", "Password123");

            // Assert
            Assert.AreEqual("Lars", patient.FirstName);
            Assert.AreEqual("Larsen", patient.LastName);
            Assert.AreEqual("lars1@gmail.com", patient.Email);
        }
    }
}
