using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class PatientTests
    {
        public PatientResource PatientResource = new PatientResource();
        public LoginResource LoginResource = new LoginResource();

        [TestInitialize]
        public void TestInitialize()
        {
            PatientResource = new PatientResource();
            LoginResource = new LoginResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllPatients_Physiotherapist_Successful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<Patient> patients = PatientResource.GetAllPatients();

            // Assert
            Assert.AreEqual(1, patients.Count());
        }

        [TestMethod]
        public void GetPatient_Patient_Succesful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            Patient patient = PatientResource.GetPatient(Resource.UserId);

            // Assert
            Assert.AreEqual(1, patient.Id);
            Assert.AreEqual("Anna", patient.FirstName);
            Assert.AreEqual("Larsen", patient.LastName);
            Assert.AreEqual("annalarsen@hotmail.com", patient.Email);
            Assert.AreEqual("26713312", patient.Phone);
            Assert.AreEqual(1957, ((DateTime)patient.BirthDate).Year);
            Assert.AreEqual(3, ((DateTime)patient.BirthDate).Month);
            Assert.AreEqual(4, ((DateTime)patient.BirthDate).Day);
            Assert.AreEqual(Sex.Female, patient.Sex);
            Assert.AreEqual((short)165, patient.Height);
            Assert.AreEqual((short)60, patient.Weight);
            Assert.AreEqual("1000", patient.ZipCode);
            Assert.AreEqual("DK", patient.CountryCode);
            Assert.AreEqual("Mitchellsgade 8", patient.Address);
        }

        [TestMethod]
        public void GetPatient_Physiotherapist_Succesful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            Patient patient = PatientResource.GetPatient(2);

            // Assert
            Assert.AreEqual(2, patient.Id);
            Assert.AreEqual("Kristian Magnus", patient.FirstName);
            Assert.AreEqual("Larsen", patient.LastName);
            Assert.AreEqual("krimaglar@hotmail.com", patient.Email);
            Assert.AreEqual("12345678", patient.Phone);
            Assert.AreEqual(1943, ((DateTime)patient.BirthDate).Year);
            Assert.AreEqual(11, ((DateTime)patient.BirthDate).Month);
            Assert.AreEqual(7, ((DateTime)patient.BirthDate).Day);
            Assert.AreEqual(Sex.Male, patient.Sex);
            Assert.AreEqual((short)175, patient.Height);
            Assert.AreEqual((short)91, patient.Weight);
            Assert.AreEqual("1000", patient.ZipCode);
            Assert.AreEqual("DK", patient.CountryCode);
            Assert.AreEqual("Ribevej 3", patient.Address);
        }

        [TestMethod]
        public void CreatePatient_Succesful()
        {
            // Arrange
            Helpers.PatientLogin();
            string firstName = "Lars";
            string lastName = "Larsen";
            string email = "lars@email.com";
            string password = "Password123";

            // Act
            Patient patient = PatientResource.CreatePatient(firstName, lastName, email, password);

            // Assert
            Assert.AreEqual(firstName, patient.FirstName);
            Assert.AreEqual(lastName, patient.LastName);
            Assert.AreEqual(email, patient.Email);
        }

        [TestMethod]
        public void UpdatePatient_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();
            Patient before = PatientResource.GetPatient(Resource.UserId);
            before.Phone = "1234";
            before.BirthDate = new DateTime(2000, 1, 1);
            before.Sex = Sex.Male;
            before.Weight = 100;
            before.Height = 100;
            before.ZipCode = "9000";
            before.CountryCode = "DK";
            before.Address = "Address";
            string currentPassword = "Password123";
            string newPassword = "123Password";

            // Act
            Patient after = PatientResource.UpdatePatient(before, currentPassword, newPassword);
            User login = LoginResource.CreateLogin(before.Email, newPassword);

            // Assert 
            Assert.AreEqual(before.FirstName, login.FirstName);
            Assert.AreEqual(before.Phone, after.Phone);
            Assert.AreEqual(before.Sex, after.Sex);
            Assert.AreEqual(before.Weight, after.Weight);
            Assert.AreEqual(before.Height, after.Height);
            Assert.AreEqual(before.ZipCode, after.ZipCode);
            Assert.AreEqual(before.CountryCode, after.CountryCode);
            Assert.AreEqual(before.Address, after.Address);
        }
    }
}