using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class JournalEntryController
    {
        private JournalEntryResource _journalEntryResource;

        public JournalEntryController()
        {
            _journalEntryResource = new JournalEntryResource();
        }

        public async Task<List<JournalEntry>> GetAllJournalEntriesByDateAsync(DateTime dateTime)
        {
            return await _journalEntryResource.GetAllJournalEntriesAsync(Resource.UserId, dateTime);
        }

        // Wierd?
        public async Task<bool> CreateJournalEntryAsync(string note)
        {
            if (note == null)
                return false;

            await _journalEntryResource.CreateJournalEntryAsync(Resource.UserId, note);
            return true;
        }
    }
}