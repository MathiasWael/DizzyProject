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
        public void GetAllExercisesTest_Successful()
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
    }
}
