using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DizzyProxy.Exceptions;
using Newtonsoft.Json.Linq;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public abstract class Resource
    {
        private static JsonWebToken _token;
        public static JsonWebToken Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
                Client.DefaultRequestHeaders.Remove("x-auth-token");
                Client.DefaultRequestHeaders.Add("x-auth-token", value.Encoded);
            }
        }

        private static HttpClient _client;
        private static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient
                    {
                        BaseAddress = new Uri("http://10.0.2.2:4000/v1/")
                    };
                }
                return _client;
            }
        }
        
        public Resource() {}

        public static string BaseAddress
        {
            set
            {
                Client.BaseAddress = new Uri(value);
            }
        }

        private async Task<string> ExecuteAsyncHelper(Request request)
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
            catch (Exception ex) when (ex is HttpRequestException || ex is WebException)
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

            return content;
        }

        protected async Task<bool> ExecuteAsync(Request request)
        {
            await ExecuteAsyncHelper(request);
            return true;
        }

        protected async Task<T> ExecuteAsync<T>(Request request)
        {
            return JsonConvert.DeserializeObject<T>(await ExecuteAsyncHelper(request));
        }
    }
}