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
        [TestMethod]
        public void GetAllFavoriteExercisesTest_Successful()
        {
            // Arrange
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            List<Exercise> exercises = new ExerciseFavoriteResource().GetAllFavoriteExercises().Result;

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
        public void CreateFavoriteExercise_Successful()
        {
            // Arrange
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");
            ExerciseFavoriteResource exerciseFavoriteResource = new ExerciseFavoriteResource();

            // Act
            List<Exercise> exercisesBefore = new ExerciseFavoriteResource().GetAllFavoriteExercises().Result;
            bool success = exerciseFavoriteResource.CreateFavoriteExercise(1).Result;
            List<Exercise> exercises = new ExerciseFavoriteResource().GetAllFavoriteExercises().Result;

            // Assert
            Assert.AreEqual(exercisesBefore.Count() + 1, exercises.Count());
            Assert.AreEqual(3, exercises.Count());
            Assert.AreEqual(1, exercises[2].Id);
            Assert.AreEqual(6, exercises[2].AuthorId);
            Assert.AreEqual("Lunges", exercises[2].Name);
            Assert.AreEqual("", exercises[2].Description);

            //Temp clean up
            bool clean = exerciseFavoriteResource.DeleteFavoriteExercise(1).Result;
        }

        [TestMethod]
        public void DeleteFavoriteExercise_Successful()
        {
            // Arrange
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");
            ExerciseFavoriteResource exerciseFavoriteResource = new ExerciseFavoriteResource();

            // Act
            List<Exercise> exercisesBefore = new ExerciseFavoriteResource().GetAllFavoriteExercises().Result;
            bool success = exerciseFavoriteResource.DeleteFavoriteExercise(3).Result;
            List<Exercise> exercises = new ExerciseFavoriteResource().GetAllFavoriteExercises().Result;

            // Assert
            Assert.AreEqual(exercisesBefore.Count() - 1, exercises.Count());
            Assert.AreEqual(1, exercises.Count());
            Assert.AreEqual(4, exercises[0].Id);
            Assert.AreEqual(7, exercises[0].AuthorId);
            Assert.AreEqual("Turn Head", exercises[0].Name);
            Assert.AreEqual("Look to your left and then your right and repeat", exercises[0].Description);

            //Temp clean up
            bool clean = exerciseFavoriteResource.CreateFavoriteExercise(3).Result;
        }
    }
}
