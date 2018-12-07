using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class PhysiotherapistController
    {
        private PhysiotherapistResource _physiotherapistResource;

        public PhysiotherapistController()
        {
            _physiotherapistResource = new PhysiotherapistResource();
        }

        public async Task<Physiotherapist> GetPhysiotherapistAsync(long id)
        {
            return await _physiotherapistResource.GetPhysiotherapistAsync(id);
        }
    }
}