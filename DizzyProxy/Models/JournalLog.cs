using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DizzyProxy.Models
{
    public class JournalLog
    {
        [JsonProperty("created")]
        public DateTime Date { get; set; }
    }
}
