using System.Net;
using System.Threading.Tasks;
using DizzyProxy.Exceptions;
using RestSharp;
using RestSharp.Deserializers;

namespace DizzyProxy.Resources
{
    public abstract class Resource
    {
        public static string Token { get; set; }

        private readonly string _baseUrl;
        private JsonDeserializer _deserializer;

        public Resource()
        {
            _baseUrl = "http://localhost:4000";
            _deserializer = new JsonDeserializer();
        }

        protected T Execute<T>(IRestRequest request) where T : new() => ExecuteAsync<T>(request).Result;
        protected async Task<T> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            if (Token != null)
                request.AddHeader("x-auth-token", Token);

            IRestClient client = new RestClient(_baseUrl);
            IRestResponse response = await ExecuteRequest<T>(client, request);

            if (!response.IsSuccessful)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest: throw new BadRequestException(response.Content);
                    case HttpStatusCode.NotFound: throw new NotFoundException(response.Content);
                    case HttpStatusCode.InternalServerError: throw new InternalServerErrorException(response.Content);
                }
            }
            
            return _deserializer.Deserialize<T>(response);
        }

        private Task<IRestResponse> ExecuteRequest<T>(IRestClient client, IRestRequest request) where T : new()
        {
            TaskCompletionSource<IRestResponse> taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync<T>(request, response => taskCompletionSource.TrySetResult(response));
            return taskCompletionSource.Task;
        }
    }
}