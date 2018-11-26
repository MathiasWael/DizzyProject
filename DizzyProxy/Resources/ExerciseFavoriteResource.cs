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
        public async Task<List<Exercise>> GetAllFavoriteExercises(long userId) 
        {
            Request request = new Request(Method.GET, "patients/"+ userId + "/favoriteexercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }

        public async Task<Exercise> CreateFavoriteExercise(long userId, long exerciseId)
        {
            Request request = new Request(Method.POST, "patients/" + userId + "/favoriteexercises");
            request.Body["exercise_id"] = exerciseId;
            return await ExecuteAsync<Exercise>(request);
        }

        public async Task<Exercise> DeleteFavoriteExercise(long userId, long exerciseId)
        {
            Request request = new Request(Method.DELETE, "patients/" + userId + "/favoriteexercises/" + exerciseId);
            return await ExecuteAsync<Exercise>(request);
        }
    }
}
