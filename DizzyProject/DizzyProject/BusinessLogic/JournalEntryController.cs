using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class JournalEntryController
    {
        private List<JournalEntry> journalEntries;

        public async void getAllJournalEntries()
        {
            journalEntries = new List<JournalEntry>();
            journalEntries = await new JournalEntryResource().GetAllJournalEntries();
        }

        public List<JournalEntry> getThisWeekJournals()
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            return journalEntries.FindAll(x => x.Created  >= dateTime);
        }

        public List<JournalEntry> getThisMonthJournals()
        {
            DateTime dateTime = new DateTime();
            DateTime dateTimeWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            return journalEntries.FindAll(x => x.Created.Month == dateTime.Month && x.Created <= dateTimeWeek);
        }

        public List<JournalEntry> getLaterJournals()
        {
            DateTime dateTime = new DateTime();
            return journalEntries.FindAll(x => x.Created.Month < dateTime.Month);
        }
    }
}
