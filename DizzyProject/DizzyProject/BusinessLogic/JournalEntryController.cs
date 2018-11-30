using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class JournalEntryController
    {
        public async Task<List<JournalEntry>> getAllJournalEntriesByDateAsync(string date)
        {
            return await new JournalEntryResource().GetAllJournalEntriesAsync(date);
        }

        public async Task<bool> CreateJournalEntryAsync(string note)
        {
            if (note != null) return await new JournalEntryResource().CreateJournalEntryAsync(note);
            else return false;
        }
    }
}
