using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class JournalLogResource : Resource
    {
        public async Task<List<JournalLog>> GetAllJournalLogs()
        {
            Request request = new Request(Method.GET, "journallogs");
            return await ExecuteAsync<List<JournalLog>>(request);
        }
    }
}
