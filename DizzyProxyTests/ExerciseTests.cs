using System;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class ExerciseTests
    {
        public WipeResource wipeResource = new WipeResource();
        public LoginResource loginResource = new LoginResource();
        public ExerciseResource exerciseResource = new ExerciseResource();

        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            wipeResource.CreateWipe();
        }

        [TestMethod]
        public void GetAllExercises_ValidInput_Successful()
        {
            // Arrange
            loginResource.CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            List<Exercise> exercises = exerciseResource.GetAllExercises();

            // Assert
            Assert.AreEqual(12, exercises.Count());
        }
    }
}
