using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxyTests
{
    public class Helpers
    {
        public static void SetBaseAddress()
        {
            Resource.BaseAddress = "http://localhost:4000/v1/";
        }
    }
}
