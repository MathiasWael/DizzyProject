using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Models
{
    public class Patient : User
    {
        public long LocationId { get; set; }

        public DateTime BirthDate { get; set; }

        public Sex Sex { get; set; }

        public short Height { get; set; }

        public short Weight { get; set; }
    }
}
