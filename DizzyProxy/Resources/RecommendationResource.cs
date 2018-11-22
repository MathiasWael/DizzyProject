using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class RecommendationResource : Resource
    {
        public async Task<List<Exercise>> GetAllRecommendations()
        {
            return new List<Exercise>()
            {
                new Exercise { Id = 12, AuthorId = 1, Name = "Exercise Recommended 1", Description="Exercise Recommended 1 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Recommended },
                new Exercise { Id = 13, AuthorId = 2, Name = "Exercise Recommended 2", Description="Exercise Recommended 2 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Recommended },
                new Exercise { Id = 14, AuthorId = 2, Name = "Exercise Recommended 3", Description="Exercise Recommended 3 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Recommended },
            };
        }
    }
}
    