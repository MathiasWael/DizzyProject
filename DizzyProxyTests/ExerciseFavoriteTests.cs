using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class ExerciseFavoriteTests
    {
        public ExerciseFavoriteResource ExerciseFavoriteResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ExerciseFavoriteResource = new ExerciseFavoriteResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllFavoriteExercises_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<Exercise> exercises = ExerciseFavoriteResource.GetAllFavoriteExercises(Resource.UserId);

            // Assert
            Assert.AreEqual(2, exercises.Count());
            Assert.AreEqual(3, exercises[0].Id);
            Assert.AreEqual(4, exercises[1].Id);
            Assert.AreEqual(7, exercises[0].AuthorId);
            Assert.AreEqual(7, exercises[1].AuthorId);
            Assert.AreEqual("Raise Shoulders", exercises[0].Name);
            Assert.AreEqual("Turn Head", exercises[1].Name);
            Assert.AreEqual("Raise your shoulders up and down and repeat", exercises[0].Description);
            Assert.AreEqual("Look to your left and then your right and repeat", exercises[1].Description);
        }

        [TestMethod]
        public void GetAllFavoriteExercises_Physiotherapist_Successful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<Exercise> exercises = ExerciseFavoriteResource.GetAllFavoriteExercises(2);

            // Assert
            Assert.AreEqual(1, exercises.Count());
            Assert.AreEqual(2, exercises[0].Id);
            Assert.AreEqual(6, exercises[0].AuthorId);
            Assert.AreEqual("Squats", exercises[0].Name);
            Assert.AreEqual("Squat down to a 90 degree angle and then up again", exercises[0].Description);
        }

        [TestMethod]
        public void CreateFavoriteExercise_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            bool success = ExerciseFavoriteResource.CreateFavoriteExercise(Resource.UserId, 1);
            List<Exercise> exercises = ExerciseFavoriteResource.GetAllFavoriteExercises(Resource.UserId);

            // Assert
            Assert.AreEqual(3, exercises.Count());
            Assert.AreEqual(1, exercises[0].Id);
            Assert.AreEqual(6, exercises[0].AuthorId);
            Assert.AreEqual("Lunges", exercises[0].Name);
            Assert.AreEqual("", exercises[0].Description);
        }

        [TestMethod]
        public void DeleteFavoriteExercise_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            bool success = ExerciseFavoriteResource.DeleteFavoriteExercise(Resource.UserId, 3);
            List<Exercise> exercises = ExerciseFavoriteResource.GetAllFavoriteExercises(Resource.UserId);

            // Assert
            Assert.AreEqual(1, exercises.Count());
        }
    }
}