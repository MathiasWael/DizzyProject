using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class JournalEntryResource : Resource
    {
        public List<JournalEntry> GetAllJournalEntriesByDate(DateTime dateTime) =>
            GetAllJournalEntriesByDateAsync(dateTime).Result;

        public async Task<List<JournalEntry>> GetAllJournalEntriesAsync(string query)
        {
            Request request = new Request(Method.GET, "patients/" + Token.Subject + "/journalentries" + query);
            return await ExecuteAsync<List<JournalEntry>>(request);
        }

        public async Task<List<JournalEntry>> GetAllJournalEntriesByDateAsync(DateTime dateTime)
        {
            string date = dateTime.ToString("yyyy-MM-dd");
            return await GetAllJournalEntriesAsync("?date=" + date);
        }

        public async Task<bool> CreateJournalEntryAsync(string note)
        {
            Request request = new Request(Method.POST, "patients/" + Token.Subject + "/journalentries");
            request.Body["note"] = note;
            return await ExecuteAsync(request);
        }
    }
}