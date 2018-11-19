using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class Patient : User
    {
        [DeserializeAs(Name = "location_id")]
        public long LocationId { get; set; }

        [DeserializeAs(Name = "birth_date")]
        public DateTime BirthDate { get; set; }

        [DeserializeAs(Name = "sex")]
        public Sex Sex { get; set; }

        [DeserializeAs(Name = "height")]
        public short Height { get; set; }

        [DeserializeAs(Name = "weight")]
        public short Weight { get; set; }
    }
}
