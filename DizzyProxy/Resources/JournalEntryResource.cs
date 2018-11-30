using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class JournalEntryResource : Resource
    {
        public List<JournalEntry> GetAllJournalEntries(string date) =>
            GetAllJournalEntriesAsync(date).Result;

        public async Task<List<JournalEntry>> GetAllJournalEntriesAsync(string date)
        {
            Request request = new Request(Method.GET, "journalentries");
            if (date != null) request.Query["date"] = date;
            return await ExecuteAsync<List<JournalEntry>>(request);
        }

        public async Task<bool> CreateJournalEntryAsync(string note)
        {
            Request request = new Request(Method.POST, "journalentries");
            request.Body["note"] = note;
            return await ExecuteAsync(request);
        }
    }
}