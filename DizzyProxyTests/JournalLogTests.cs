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
    public class JournalLogTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllJournalLogsTest_Successful()
        {
            // Arrange
            Helpers.Login();

            // Act
            List<JournalLog> journalLogs = new JournalLogResource().GetAllJournalLogsAsync().Result;

            // Assert
            Assert.AreEqual(6, journalLogs.Count());
        }
    }
}
