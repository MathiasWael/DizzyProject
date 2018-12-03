﻿using System;
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
        [TestInitialize]
        public void TestInitialize()
        {
            Helpers.SetBaseAddress();
            Helpers.Wipe();
        }

        [TestMethod]
        public void GetAllJournalLogsByDateTest_Successful()
        {
            // Arrange
            Helpers.Login();
            DateTime dateTime = new DateTime(2018, 10, 15);

            // Act
            List<JournalEntry> journalEntries = new JournalEntryResource().GetAllJournalEntriesByDate(dateTime);

            // Assert
            Assert.AreEqual(4, journalEntries.Count());
        }

        [TestMethod]
        public void CreateJournalEntry_ValidInput_Successful()
        {
            // Arrange
            Helpers.Login();
            JournalEntryResource journalEntryResource = new JournalEntryResource();
            string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            string journalEntryNote = "Testing Journal Entry";
            DateTime dateTime = new DateTime(2018, 10, 15);
            List<JournalEntry> journalEntriesBefore = journalEntryResource.GetAllJournalEntriesByDate(dateTime);

            // Act
            bool success = journalEntryResource.CreateJournalEntryAsync(journalEntryNote).Result;
            List<JournalEntry> journalEntriesAfter = journalEntryResource.GetAllJournalEntriesByDate(dateTime);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(journalEntriesBefore.Count() + 1, journalEntriesAfter.Count());
            Assert.AreEqual(true, journalEntriesAfter.Exists(x => x.Note == journalEntryNote));
            Assert.AreEqual(false, journalEntriesBefore.Exists(x => x.Note == journalEntryNote));
        }

        [TestMethod]
        public void CreateJournalEntry_InvalidInput_NoteLength()
        {
            // Arrange
            Helpers.Login();
            string journalEntryNote = "Aenean id rutrum lectus, sit amet volutpat lorem. In porta libero quis blandit eleifend. Pellentesque tincidunt nibh pulvinar purus ornare, id consectetur mauris scelerisque. Donec scelerisque fermentum imperdiet. In pellentesque, purus ac elementum semper, purus neque suscipit dolor, non porta turpis nulla ut leo. In nec turpis at neque sollicitudin pellentesque. Integer pulvinar fringilla erat. Mauris non volutpat ligula. Suspendisse efficitur urna a nunc blandit convallis. Phasellus sit amet urna a mauris porta consectetur vitae a turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Fusce urna ipsum, efficitur sit amet purus eu, scelerisque vulputate nunc. Nullam eget molestie risus, at vestibulum nisl. Donec rhoncus mauris felis. Proin ornare semper augue, a tempor tellus tristique non. Nulla ac urna et massa facilisis sodales eleifend nec ante. Integer tristique pellentesque tincidunt. Fusce ac lectus convallis, cursus quam nec, tempus erat. Phasellus id risus non metus.";
            bool success = false;

            // Act
            try
            {
                success = new JournalEntryResource().CreateJournalEntryAsync(journalEntryNote).Result;
            }
            catch (AggregateException e)
            {
                Assert.IsFalse(success);
                Assert.AreEqual("\"note\" length must be less than or equal to 1000 characters long", e.InnerException.Message);
            }
        }

        [TestMethod]
        public void CreateJournalEntry_InvalidInput_NoteRequired()
        {
            // Arrange
            Helpers.Login();
            string journalEntryNote = null;
            bool success = false;

            // Act
            try
            {
                success = new JournalEntryResource().CreateJournalEntryAsync(journalEntryNote).Result;
            }

            // Assert
            catch (AggregateException e)
            {
                Assert.IsFalse(success);
                Assert.AreEqual("\"note\" must be a string", e.InnerException.Message);
            }
        }
    }
}