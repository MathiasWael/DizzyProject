using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class Patient : User
    {
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("birth_date")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty("sex")]
        public Sex? Sex { get; set; }

        [JsonProperty("height")]
        public short? Height { get; set; }

        [JsonProperty("weight")]
        public short? Weight { get; set; }
    }
}
