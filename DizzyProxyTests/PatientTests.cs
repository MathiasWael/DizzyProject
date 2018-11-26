using System;
using DizzyProxy.Resources;
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
            Patient patient = patients.CreatePatient("Lars", "Larsen", "lars1@gmail.com", "Password123");

            // Assert
            Assert.AreEqual("Lars", patient.FirstName);
            Assert.AreEqual("Larsen", patient.LastName);
            Assert.AreEqual("lars1@gmail.com", patient.Email);
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
