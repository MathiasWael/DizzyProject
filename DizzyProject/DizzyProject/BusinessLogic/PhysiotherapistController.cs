using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class PhysiotherapistController
    {

        public async Task<Physiotherapist> GetPhysioByIdAsync(long id)
        {
            return await new PhysiotherapistResource().GetPhysiotherapistAsync(id);
        }
    }
}
