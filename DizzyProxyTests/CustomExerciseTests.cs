using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxyTests
{
    [TestClass]
    public class CustomExerciseTests
    {
        public CustomExerciseResource CustomExerciseResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            CustomExerciseResource = new CustomExerciseResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllCustomExercises_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<Exercise> exercises = CustomExerciseResource.GetAllCustomExercises(Resource.UserId);

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

        [TestMethod]
        public void GetAllCustomExercises_Physiotherapist_Successful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<Exercise> exercises = CustomExerciseResource.GetAllCustomExercises(2);

            // Assert
            Assert.AreEqual(1, exercises.Count());
            Assert.AreEqual(6, exercises[0].Id);
            Assert.AreEqual(7, exercises[0].AuthorId);
            Assert.AreEqual("Jumping Jacks without arms", exercises[0].Name);
            Assert.AreEqual("Do standard jumping jack but without moving your arms", exercises[0].Description);
        }
    }
}