using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public long CountryId { get; set; }
    }
}
