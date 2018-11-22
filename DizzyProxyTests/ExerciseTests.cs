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
    public class ExerciseTests
    {
        [TestMethod]
        public void GetAllExercisesTest_Successful()
        {
            // Arrange
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            List<Exercise> exercises = new ExerciseResource().GetAllExercises().Result;

            // Assert
            Assert.AreEqual(4, exercises.Count());
        }

        [TestMethod]
        public void getExercise_fromId()
        {
            // Arrange
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");

            //Act
            List<Exercise> exercises = new ExerciseResource().GetAllExercises().Result;

            //Assert
            Assert.IsTrue(exercises[5].Description == "Touch Toes', 'Bend down and touch your toes and up again and repeat");
        }
    }
}
