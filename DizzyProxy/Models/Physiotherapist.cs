using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class Physiotherapist : User
    {
        [JsonProperty("organisation_id")]
        public long DepartmentId { get; set; }
    }
}
