using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Exceptions;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DizzyProxyTests
{
    [TestClass]
    public class JournalEntryTests
    {
        public JournalEntryResource JournalEntryResource { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            JournalEntryResource = new JournalEntryResource();
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllJournalEntries_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();

            // Act
            List<JournalEntry> journalEntries = JournalEntryResource.GetAllJournalEntries(Resource.UserId);

            // Assert
            Assert.AreEqual(10, journalEntries.Count);
        }

        [TestMethod]
        public void GetAllJournalEntries_Patient_ByDate_Successful()
        {
            // Arrange
            Helpers.PatientLogin();
            DateTime date = new DateTime(2018, 11, 23);

            // Act
            List<JournalEntry> journalEntries = JournalEntryResource.GetAllJournalEntries(Resource.UserId, date);

            // Assert
            Assert.AreEqual(1, journalEntries.Count);
            Assert.AreEqual(3, journalEntries[0].Id);
            Assert.AreEqual(1, journalEntries[0].PatientId);
            Assert.AreEqual("I dag har jeg det ikke så godt", journalEntries[0].Note);
        }

        [TestMethod]
        public void GetAllJournalEntries_Physiotherapist_Successful()
        {
            // Arrange
            Helpers.PhysiotherapistLogin();

            // Act
            List<JournalEntry> journalEntries = JournalEntryResource.GetAllJournalEntries(2);

            // Assert
            Assert.AreEqual(0, journalEntries.Count);
        }

        [TestMethod]
        public void CreateJournalEntry_Patient_Successful()
        {
            // Arrange
            Helpers.PatientLogin();
            string note = "Note";

            // Act
            JournalEntry journalEntry = JournalEntryResource.CreateJournalEntry(Resource.UserId, note);

            // Assert
            Assert.AreEqual(11, journalEntry.Id);
            Assert.AreEqual(1, journalEntry.PatientId);
            Assert.AreEqual(note, journalEntry.Note);
        }
    }
}