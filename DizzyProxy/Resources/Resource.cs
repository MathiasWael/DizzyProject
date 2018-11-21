using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DizzyProxy.Exceptions;

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
            if (Token != null)
                Client.DefaultRequestHeaders.Add("x-auth-token", Token);

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
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest: throw new BadRequestException(content);
                    case HttpStatusCode.Unauthorized: throw new UnauthorizedException(content);
                    case HttpStatusCode.Forbidden: throw new ForbiddenException(content);
                    case HttpStatusCode.NotFound: throw new NotFoundException(content);
                    case HttpStatusCode.InternalServerError: throw new InternalServerErrorException(content);
                }
            }

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}