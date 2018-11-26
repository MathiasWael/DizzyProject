using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DizzyProxy.Models
{
    public class Recommendation
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("physiotherapist_id")]
        public long PhysiotherapistId { get; set; }
        [JsonProperty("exercise_id")]
        public long ExerciseId { get; set; }
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
