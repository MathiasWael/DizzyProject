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
    public class JournalEntryTests
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
            List<JournalEntry> journalEntries = new JournalEntryResource().GetAllJournalEntries("2018-11-28");

            // Assert
            Assert.AreEqual(2, journalEntries.Count());
        }
    }
}
