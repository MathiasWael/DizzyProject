﻿using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class JournalLogResource : Resource
    {
        public async Task<List<JournalLog>> GetAllJournalLogsAsync()
        {
            Request request = new Request(Method.GET, "patients/" + Token.Subject + "/journallogs");
            return await ExecuteAsync<List<JournalLog>>(request);
        }
    }
}
