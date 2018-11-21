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
        public List<Exercise> GetFavoritesById(long userId) 
        {
            return new List<Exercise>()
            {
                new Exercise { Id = 6, AuthorId = 1, Name = "Exercise Favorite 1", Description="Exercise Favorite 1 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Favorite },
                new Exercise { Id = 7, AuthorId = 2, Name = "Exercise Favorite 2", Description="Exercise Favorite 2 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Favorite },
                new Exercise { Id = 8, AuthorId = 2, Name = "Exercise Favorite 3", Description="Exercise Favorite 3 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Favorite },
            };
        }

        public Exercise FavoriteExercise(long userId, long exerciseId)
        {
            return new Exercise();
        }

        public Exercise UnfavoriteExercise(long userId, long exerciseId)
        {
            return new Exercise();
        }
    }
}
