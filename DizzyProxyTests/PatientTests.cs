using System;
using DizzyProxy;
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
            Patient patient = patients.CreatePatient("Lasse", "Olesen", "test@gmail.com", "Password123");

            // Assert
            Assert.AreEqual("Lasse", patient.FirstName);
            Assert.AreEqual("Olesen", patient.LastName);
            Assert.AreEqual("test@gmail.com", patient.Email);
        }
    }
}
