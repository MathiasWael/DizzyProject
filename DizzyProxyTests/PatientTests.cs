using DizzyProxy.Resources;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class PatientTests
    {
        public PatientResource patientResource = new PatientResource();

        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
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
            Helpers.Login();

            // Act
            List<Patient> patients = new PatientResource().GetAllPatients();

            // Assert
            Assert.AreEqual(5, patients.Count());
        }

        [TestMethod]
        public void UpdateExistingPatient_ValidInput_Successful()
        {
            // Arrange
            Helpers.Login();
            Patient patient = patientResource.GetPatient(1);
            patient.Address = "Test123";
            patient.Phone = "12345678";
            patient.Sex = Sex.Male;
            patient.ZipCode = "9000";
            patient.Weight = 100;
            patient.Height = 100;
            patient.CountryCode = "JP";

            // Act
            patientResource.UpdatePatient(patient, null, null);
            Patient updatedPatient = patientResource.GetPatient(1);

            // Assert 
            Assert.IsTrue(patient.Address == updatedPatient.Address);
            Assert.IsTrue(patient.Phone == updatedPatient.Phone);
            Assert.IsTrue(patient.Sex == updatedPatient.Sex);
            Assert.IsTrue(patient.ZipCode == updatedPatient.ZipCode);
            Assert.IsTrue(patient.Weight == updatedPatient.Weight);
            Assert.IsTrue(patient.Height == updatedPatient.Height);
            Assert.IsTrue(patient.CountryCode == updatedPatient.CountryCode);
        }

        [TestMethod]
        public void UddateNewPatient_ValidInput_Sucessful()
        {
            // Arrange
            Patient patient = patientResource.CreatePatient("Test", "Bruger", "test@bruger.com", "Password123");
            LoginResource loginResource = new LoginResource();
            loginResource.CreateLogin("test@bruger.com", "Password123");

            patient.Address = "Test123";
            patient.Phone = "12345678";
            patient.Sex = Sex.Male;
            patient.ZipCode = "9000";
            patient.Weight = 100;
            patient.Height = 100;
            patient.CountryCode = "JP";

            // Act
            patientResource.UpdatePatient(patient, null, null);
            Patient updatedPatient = patientResource.GetPatient(patient.Id);

            // Assert 
            Assert.IsTrue(patient.Address == updatedPatient.Address);
            Assert.IsTrue(patient.Phone == updatedPatient.Phone);
            Assert.IsTrue(patient.Sex == updatedPatient.Sex);
            Assert.IsTrue(patient.ZipCode == updatedPatient.ZipCode);
            Assert.IsTrue(patient.Weight == updatedPatient.Weight);
            Assert.IsTrue(patient.Height == updatedPatient.Height);
            Assert.IsTrue(patient.CountryCode == updatedPatient.CountryCode);
        }

    }
}