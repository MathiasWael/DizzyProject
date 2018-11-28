using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class RecommendationController
    {
        RecommendationResource recResource;
        public async Task<Recommendation> GetRecByIdAsync(long id)
        {
            return await recResource.getRecommendationById(id);
        }
    }
}
