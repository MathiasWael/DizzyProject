using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class JournalEntryResource : Resource
    {
        public List<JournalEntry> GetAllJournalEntries(long userId) =>
            GetAllJournalEntriesAsync(userId).Result;

        public async Task<List<JournalEntry>> GetAllJournalEntriesAsync(long userId)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/journalentries");
            return await ExecuteAsync<List<JournalEntry>>(request);
        }

        public List<JournalEntry> GetAllJournalEntries(long userId, DateTime dateTime) =>
            GetAllJournalEntriesAsync(userId, dateTime).Result;

        public async Task<List<JournalEntry>> GetAllJournalEntriesAsync(long userId, DateTime dateTime)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/journalentries");
            request.Query["date"] = dateTime.ToString("yyyy-MM-dd");
            return await ExecuteAsync<List<JournalEntry>>(request);
        }

        public JournalEntry CreateJournalEntry(long userId, string note) =>
            CreateJournalEntryAsync(userId, note).Result;

        public async Task<JournalEntry> CreateJournalEntryAsync(long userId, string note)
        {
            Request request = new Request(Method.POST, $"patients/{userId}/journalentries");
            request.Body["note"] = note;
            return await ExecuteAsync<JournalEntry>(request);
        }
    }
}