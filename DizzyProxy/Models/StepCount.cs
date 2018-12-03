using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class StepCount
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("patient_id")]
        public long PatientId { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
