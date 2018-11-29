using System.Collections.Generic;

namespace DizzyProxy.Resources
{
    public class Request
    {
        public Method Method { get; set; }
        public Dictionary<string, object> Body { get; set; }
        public Dictionary<string, object> Query { get; set; }

        private string _path;
        public string Path
        {
            get
            {
                return _path += BuildQueryString();
            }
            set
            {
                _path = value;
            }
        }

        public Request(Method method, string path)
        {
            Method = method;
            Path = path;
            Body = new Dictionary<string, object>();
            Query = new Dictionary<string, object>();
        }

        private string BuildQueryString()
        {
            string queryString = string.Empty;

            if (Query.Count > 0)
            {
                bool first = true;
                foreach (string key in Query.Keys)
                {
                    if (first)
                    {
                        queryString += $"?{key}={Query[key]}";
                        first = false;
                    }
                    else
                    {
                        queryString += $"&{key}={Query[key]}";
                    }
                }
            }

            return queryString;
        }
    }
}