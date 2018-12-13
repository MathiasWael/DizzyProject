using DizzyProxy.Models;
using System;
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

        public StepCount CreateStepCount(long userId, int count, DateTime dateTime)
            => CreateStepCountAsync(userId, count, dateTime).Result;

        public async Task<StepCount> CreateStepCountAsync(long userId, int count, DateTime dateTime)
        {
            Request request = new Request(Method.POST, $"patients/{userId}/stepcounts");
            request.Body["patient_id"] = userId;
            request.Body["count"] = count;
            request.Body["date"] = dateTime.ToString("yyyy-MM-dd");
            return await ExecuteAsync<StepCount>(request);
        }

        public StepCount UpdateStepCount(StepCount stepCount)
            => UpdateStepCountAsync(stepCount).Result;

        public async Task<StepCount> UpdateStepCountAsync(StepCount stepCount)
        {
            Request request = new Request(Method.PUT, $"patients/{stepCount.PatientId}/stepcounts/{stepCount.Id}");
            request.Body["patient_id"] = stepCount.PatientId;
            request.Body["count"] = stepCount.Count;
            request.Body["date"] = stepCount.Date.ToString("yyyy-MM-dd");
            return await ExecuteAsync<StepCount>(request);
        }
    }
}