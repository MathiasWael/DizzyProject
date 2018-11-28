﻿using DizzyProxy.Resources;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class PatientTests
    {
        public WipeResource wipeResource = new WipeResource();
        public LoginResource loginResource = new LoginResource();
        public PatientResource patientResource = new PatientResource();

        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            wipeResource.CreateWipe();
        }

        [TestMethod]
        public void CreatePatient_ValidInput_Succesful()
        {
            // Act
            Patient patient = patientResource.CreatePatient("Lars", "Larsen", "lars@email.com", "Password123");

            // Assert
            Assert.AreEqual("Lars", patient.FirstName);
            Assert.AreEqual("Larsen", patient.LastName);
            Assert.AreEqual("lars@email.com", patient.Email);
        }

        [TestMethod]
        public void GetAllPatients_ValidInput_Successful()
        {
            // Arrange
            loginResource.CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            List<Patient> patients = new PatientResource().GetAllPatients();

            // Assert
            Assert.AreEqual(5, patients.Count());
        }

    }
}