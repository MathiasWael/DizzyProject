using System.Net;
using System.Threading.Tasks;
using DizzyProxy.Exceptions;
using RestSharp;

namespace DizzyProxy.Resources
{
    public abstract class Resource
    {
        public static string Token { get; set; }
        private const string BaseUrl = "http://localhost:4000";

        public Resource()
        {

        }

        private Task<IRestResponse> Execute<T>(IRestRequest request) where T : new()
        {
            IRestClient client = new RestClient(BaseUrl);
            TaskCompletionSource<IRestResponse> taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync<T>(request, response => taskCompletionSource.TrySetResult(response));
            return taskCompletionSource.Task;
        }

        protected async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            if (Token != null)
                request.AddHeader("x-auth-token", Token);
            
            IRestResponse response = await Execute<T>(request);

            if (!response.IsSuccessful)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest: throw new BadRequestException(response.Content);
                    case HttpStatusCode.NotFound: throw new NotFoundException(response.Content);
                    case HttpStatusCode.InternalServerError: throw new InternalServerErrorException(response.Content);
                }
            }

            return new T();
        }
    }
}