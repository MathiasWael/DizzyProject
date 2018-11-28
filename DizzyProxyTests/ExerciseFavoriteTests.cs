using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class ExerciseFavoriteTests
    {
        public ExerciseFavoriteResource exerciseFavoriteResource = new ExerciseFavoriteResource();

        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllFavoriteExercises_ValidInput_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<Exercise> exercises = exerciseFavoriteResource.GetAllFavoriteExercises();

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
        public void CreateFavoriteExercise__ValidInput_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<Exercise> exercisesBefore = exerciseFavoriteResource.GetAllFavoriteExercises();
            bool success = exerciseFavoriteResource.CreateFavoriteExercise(1);
            List<Exercise> exercises = exerciseFavoriteResource.GetAllFavoriteExercises();

            // Assert
            Assert.AreEqual(exercisesBefore.Count() + 1, exercises.Count());
            Assert.AreEqual(3, exercises.Count());
            Assert.AreEqual(1, exercises[2].Id);
            Assert.AreEqual(6, exercises[2].AuthorId);
            Assert.AreEqual("Lunges", exercises[2].Name);
            Assert.AreEqual("", exercises[2].Description);
        }

        [TestMethod]
        public void DeleteFavoriteExercise_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<Exercise> exercisesBefore = exerciseFavoriteResource.GetAllFavoriteExercises();
            bool success = exerciseFavoriteResource.DeleteFavoriteExercise(3);
            List<Exercise> exercises = exerciseFavoriteResource.GetAllFavoriteExercises();

            // Assert
            Assert.AreEqual(exercisesBefore.Count() - 1, exercises.Count());
            Assert.AreEqual(1, exercises.Count());
            Assert.AreEqual(4, exercises[0].Id);
            Assert.AreEqual(7, exercises[0].AuthorId);
            Assert.AreEqual("Turn Head", exercises[0].Name);
            Assert.AreEqual("Look to your left and then your right and repeat", exercises[0].Description);
        }
    }
}
