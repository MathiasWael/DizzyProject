using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class DizzinessTest
    {
        LoginResource lr = new LoginResource();
        DizzinessResource dr = new DizzinessResource();

        [TestMethod]
        public void CreateDizzinessTest_Successful() //dun work, login giver connection fejl
        {
            // Arrange
            lr.CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            Dizziness d = dr.Submit(null, 7, "Er svimmel i dag - Anna");

            // Assert
            Assert.AreEqual(d.Note, "Er svimmel i dag - Anna");
            Assert.AreEqual(d.Level, 7);
        }
    }
}
