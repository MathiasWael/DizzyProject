using RestSharp;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Exceptions;

namespace DizzyProxy.Resources
{
    public abstract class Resource
    {
        private const string BaseUrl = "https://localhost:4000";

        public Resource()
        {

        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            IRestClient client = new RestClient(BaseUrl);
            IRestResponse response = client.Execute<T>(request);

            if (!response.IsSuccessful)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest: throw new BadRequestException(); break;
                    case HttpStatusCode.InternalServerError: throw new BadRequestException(); break;
                }
            }
            
        }
    }
}
