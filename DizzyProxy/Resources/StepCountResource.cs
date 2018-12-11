using DizzyProxy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class StepCountResource : Resource
    {
        public List<StepCount> GetAllStepCounts(long userId)
            => GetAllStepCountsAsync(userId).Result;

        public async Task<List<StepCount>> GetAllStepCountsAsync(long userId)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/stepcounts");
            return await ExecuteAsync<List<StepCount>>(request);
        }
    }
}