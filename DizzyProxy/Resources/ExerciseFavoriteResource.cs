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
        public async Task<List<Exercise>> GetAllFavoriteExercises() 
        {
            Request request = new Request(Method.GET, "favoriteexercises");
            return await ExecuteAsync<List<Exercise>>(request);
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
