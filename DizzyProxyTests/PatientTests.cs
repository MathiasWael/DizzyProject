using System;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy;
using DizzyProxy.Models;
using DizzyProxy.Resources;
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
            Patient patient = patients.CreatePatient("Lasse", "Olesen", "test6@gmail.com", "Password123");

            // Assert
            Assert.AreEqual("Lasse", patient.FirstName);
            Assert.AreEqual("Olesen", patient.LastName);
            Assert.AreEqual("test6@gmail.com", patient.Email);
        }

        [TestMethod]
        public void GetAllPatientsTest_Successful()
        {
            // Arrange
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            List<Patient> patients = new PatientResource().GetAllPatientsAsync().Result;

            // Assert
            Assert.AreEqual(5, patients.Count());
        }

    }
}
