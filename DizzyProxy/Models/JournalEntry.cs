﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class JournalEntry
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("patient_id")]
        public long PatientId { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
    }
}
