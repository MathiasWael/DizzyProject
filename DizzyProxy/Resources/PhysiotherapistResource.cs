using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class PhysiotherapistResource : Resource
    {
        public Physiotherapist GetPhysiotherapist(long id)
            => GetPhysiotherapistAsync(id).Result;

        public async Task<Physiotherapist> GetPhysiotherapistAsync(long id)
        {
            Request request = new Request(Method.GET, $"physiotherapists/{id}");
            return await ExecuteAsync<Physiotherapist>(request);
        }
    }
}
