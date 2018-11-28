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
            return await new JournalEntryResource().GetAllJournalEntries(date);
        }
    }
}
