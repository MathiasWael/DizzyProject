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
        [TestMethod]
        public void CreateDizzinessTest_Successful() //dun work, login giver connection fejl
        {
            // Arrange
            DizzinessResource dc = new DizzinessResource();
            new LoginResource().CreateLogin("annalarsen@hotmail.com", "Password123");

            // Act
            Task<Dizziness> td = dc.SubmitAsync(null, 7, "Er svimmel i dag - Anna");
            Dizziness d = (Dizziness)td.AsyncState;

            // Assert
            Assert.AreEqual(d.Note, "Er svimmel i dag - Anna");
            Assert.AreEqual(d.Level, 7);
        }
    }
}
