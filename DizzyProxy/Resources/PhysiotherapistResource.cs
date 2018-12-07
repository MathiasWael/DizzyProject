using DizzyProxy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class PhysiotherapistResource : Resource
    {
        public List<Physiotherapist> GetAllPhysiotherapists()
            => GetAllPhysiotherapistsAsync().Result;

        public async Task<List<Physiotherapist>> GetAllPhysiotherapistsAsync()
        {
            Request request = new Request(Method.GET, "physiotherapists");
            return await ExecuteAsync<List<Physiotherapist>>(request);
        }

        public Physiotherapist GetPhysiotherapist(long id)
            => GetPhysiotherapistAsync(id).Result;

        public async Task<Physiotherapist> GetPhysiotherapistAsync(long id)
        {
            Request request = new Request(Method.GET, $"physiotherapists/{id}");
            return await ExecuteAsync<Physiotherapist>(request);
        }
    }
}