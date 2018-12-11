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
        public ExerciseResource ExerciseResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ExerciseResource = new ExerciseResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllExercises_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<Exercise> exercises = ExerciseResource.GetAllExercises();

            // Assert
            Assert.AreEqual(12, exercises.Count());
        }

        [TestMethod]
        public void GetExercise_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            Exercise exercise = ExerciseResource.GetExercise(1);

            // Assert
            Assert.AreEqual(1, exercise.Id);
            Assert.AreEqual(6, exercise.AuthorId);
            Assert.AreEqual("Lunges", exercise.Name);
            Assert.AreEqual("", exercise.Description);
        }
    }
}
