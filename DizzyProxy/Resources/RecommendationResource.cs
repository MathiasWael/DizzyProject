﻿using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class RecommendationResource : Resource
    {
        public List<Exercise> GetRecommendationsById(long userId)
        {
            return new List<Exercise>()
            {
                new Exercise { Id = 12, AuthorId = 1, Name = "Exercise Recommended 1", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 13, AuthorId = 2, Name = "Exercise Recommended 2", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 14, AuthorId = 2, Name = "Exercise Recommended 3", Created = DateTime.Now, Updated = DateTime.Now },
            };
        }
    }
}
