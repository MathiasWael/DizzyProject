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
        public long Id { get; set; }
        public long PhysiotherapistId { get; set; }
        public long ExerciseId { get; set; }
        public long PatientId { get; set; }
        public string Note { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
    }
}
