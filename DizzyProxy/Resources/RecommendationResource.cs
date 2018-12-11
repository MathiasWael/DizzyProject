using DizzyProxy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class RecommendationResource : Resource
    {
        public List<Recommendation> GetAllRecommendations(long userId)
            => GetAllRecommendationsAsync(userId).Result;

        public async Task<List<Recommendation>> GetAllRecommendationsAsync(long userId)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/recommendations");
            return await ExecuteAsync<List<Recommendation>>(request);
        }
    }
}