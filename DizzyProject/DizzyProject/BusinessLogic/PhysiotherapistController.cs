﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class PhysiotherapistController
    {
        PhysiotherapistResource physRes;
        public async Task<Physiotherapist> GetPhysioById(long id)
        {
            return await physRes.GetPhysiotherapistAsync(id);
        }
    }
}
