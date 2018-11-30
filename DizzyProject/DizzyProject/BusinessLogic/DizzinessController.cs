using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Resources;
using DizzyProxy.Models;

namespace DizzyProject.BusinessLogic
{
    public class DizzinessController
    {
        DizzinessResource dr = new DizzinessResource();

        public async Task<Dizziness> SubmitAsync(int dizziness, string note)
        {
            return await dr.SubmitAsync(null, dizziness, note);
        }

        public async Task<List<Dizziness>> getAllDizzinessesByDateAsync(string date)
        {
            return await new DizzinessResource().GetAllDizzinessesAsync(date);
        }
    }
}
