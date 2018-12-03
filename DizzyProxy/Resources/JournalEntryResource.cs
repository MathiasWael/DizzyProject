﻿using System;
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
            Request request = new Request(Method.GET, "journalentries" + query);
            return await ExecuteAsync<List<JournalEntry>>(request);
        }

        public async Task<List<JournalEntry>> GetAllJournalEntriesByDateAsync(DateTime dateTime)
        {
            string date = dateTime.Year.ToString() + "-" + dateTime.Month + "-" + dateTime.Day;
            return await GetAllJournalEntriesAsync("?date=" + date);
        }

        public async Task<bool> CreateJournalEntryAsync(string note)
        {
            Request request = new Request(Method.POST, "journalentries");
            request.Body["note"] = note;
            return await ExecuteAsync(request);
        }
    }
}