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
            new LoginResource().CreateLogin("mathiaswael@hotmail.dk", "Password1");

            // Act
            List<Exercise> exercises = new ExerciseResource().GetAllExercises().Result;

            // Assert
            Assert.AreEqual(4, exercises.Count());
        }
    }
}
