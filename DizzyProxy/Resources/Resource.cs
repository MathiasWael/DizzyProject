using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DizzyProxy.Exceptions;
using Newtonsoft.Json.Linq;

namespace DizzyProxy.Resources
{
    public abstract class Resource
    {
        private static string _token;
        public static string Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
                Client.DefaultRequestHeaders.Remove("x-auth-token");
                Client.DefaultRequestHeaders.Add("x-auth-token", value);
            }
        }

        private static HttpClient Client { get; set; }

        public Resource()
        {
            if (Client == null)
                Client = new HttpClient { BaseAddress = new Uri("http://localhost:4000/v1/") };
        }

        protected async Task<T> ExecuteAsync<T>(Request request)
        {
            string json = JsonConvert.SerializeObject(request.Body, Formatting.Indented);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            try
            {
                switch (request.Method)
                {
                    case Method.GET: response = await Client.GetAsync(request.Path); break;
                    case Method.POST: response = await Client.PostAsync(request.Path, body); break;
                    case Method.PUT: response = await Client.PutAsync(request.Path, body); break;
                    case Method.DELETE: response = await Client.DeleteAsync(request.Path); break;
                    default: throw new ApplicationException("Request method not set");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ConnectionException("Unable to connect to the service", ex);
            }

            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(content);
                int code = jObject["code"].ToObject<int>();
                string message = jObject["message"].ToObject<string>();
                throw new ApiException(response.StatusCode, code, message);
            }

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}