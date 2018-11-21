using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class Request
    {
        public Method Method { get; set; }
        public string Path { get; set; }
        public Dictionary<string, object> Body { get; set; }

        public Request(Method method, string path)
        {
            Method = method;
            Path = path;
            Body = new Dictionary<string, object>();
        }
    }
}
