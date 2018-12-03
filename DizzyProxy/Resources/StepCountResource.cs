using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class StepCountResource : Resource
    {
        public async Task<List<StepCount>> GetAllStepCountsAsync()
        {
            Request request = new Request(Method.GET, "stepcounts");
            return await ExecuteAsync<List<StepCount>>(request);
        }
    }
}
