using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class ExerciseFavoriteResource : Resource
    {
        public List<Exercise> GetFavoritesById() 
        {
            return new List<Exercise>()
            {
                new Exercise { Id = 6, AuthorId = 1, Name = "Exercise Favorite 1", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 7, AuthorId = 2, Name = "Exercise Favorite 2", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 8, AuthorId = 2, Name = "Exercise Favorite 3", Created = DateTime.Now, Updated = DateTime.Now },
            };
        }
    }
}
