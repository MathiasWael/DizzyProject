﻿using System;
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
        }
    }
}