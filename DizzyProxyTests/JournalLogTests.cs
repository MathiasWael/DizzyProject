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
        public JournalLogResource JournalLogResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            JournalLogResource = new JournalLogResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllJournalLogsTest_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<JournalLog> journalLogs = JournalLogResource.GetAllJournalLogs(Resource.UserId);

            // Assert
            Assert.AreEqual(26, journalLogs.Count());
        }

        [TestMethod]
        public void GetAllJournalLogsTest_Physiotherapist_Successful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<JournalLog> journalLogs = JournalLogResource.GetAllJournalLogs(2);

            // Assert
            Assert.AreEqual(1, journalLogs.Count());
        }
    }
}
