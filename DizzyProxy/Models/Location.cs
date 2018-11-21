using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class Location
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public long CityId { get; set; }
        public int ZipCode { get; set; }
        public long CountryId { get; set; }
    }
}
