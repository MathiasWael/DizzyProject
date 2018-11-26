using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class RecommendationResource : Resource
    {
        public async Task<List<Recommendation>> GetAllRecommendations()
        {
            Request request = new Request(Method.GET, "recommendations");
            return await ExecuteAsync<List<Recommendation>>(request);
        }
    }
}
    