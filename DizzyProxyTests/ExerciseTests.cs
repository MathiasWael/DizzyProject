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
        public ExerciseResource exerciseResource = new ExerciseResource();

        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllExercises_ValidInput_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<Exercise> exercises = exerciseResource.GetAllExercises();

            // Assert
            Assert.AreEqual(12, exercises.Count());
        }
    }
}
