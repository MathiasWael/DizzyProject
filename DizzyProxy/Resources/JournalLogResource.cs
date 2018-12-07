using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class JournalLogResource : Resource
    {
        public List<JournalLog> GetAllJournalLogs(long userId) 
            => GetAllJournalLogsAsync(userId).Result;

        public async Task<List<JournalLog>> GetAllJournalLogsAsync(long userId)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/journallogs");
            return await ExecuteAsync<List<JournalLog>>(request);
        }
    }
}