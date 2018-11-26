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
    public class CustomExerciseTests
    {
        [TestMethod]
        public void GetAllExercisesTest_Successful()
        {
            // Arrange
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            List<Exercise> exercises = new CustomExercisePatientResource().GetAllCustomExercises().Result;

            // Assert
            Assert.AreEqual(2, exercises.Count());
            Assert.AreEqual(5, exercises[0].Id);
            Assert.AreEqual(6, exercises[1].Id);
            Assert.AreEqual(7, exercises[0].AuthorId);
            Assert.AreEqual(7, exercises[1].AuthorId);
            Assert.AreEqual("Touch Toes", exercises[0].Name);
            Assert.AreEqual("Jumping Jacks without arms", exercises[1].Name);
            Assert.AreEqual("Bend down and touch your toes and up again and repeat", exercises[0].Description);
            Assert.AreEqual("Do standard jumping jack but without moving your arms", exercises[1].Description);
        }
    }
}
