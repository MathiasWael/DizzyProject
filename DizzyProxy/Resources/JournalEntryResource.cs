using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class JournalEntryResource : Resource
    {
        public async Task<List<JournalEntry>> GetAllJournalEntries()
        {
            Request request = new Request(Method.GET, "journalentries");
            return await ExecuteAsync<List<JournalEntry>>(request);
        }
    }
}
