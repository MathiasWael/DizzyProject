using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class User
    {
        [DeserializeAs(Name = "id")]
        public long Id { get; set; }

        [DeserializeAs(Name = "first_name")]
        public string FirstName { get; set; }

        [DeserializeAs(Name = "last_name")]
        public string LastName { get; set; }

        [DeserializeAs(Name = "email")]
        public string Email { get; set; }

        [DeserializeAs(Name = "created")]
        public DateTime Created { get; set; }

        [DeserializeAs(Name = "updated")]
        public DateTime Updated { get; set; }
    }
}
