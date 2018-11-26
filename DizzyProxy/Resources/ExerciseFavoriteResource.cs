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
            Request request = new Request(Method.GET, "patients/"+ Token.Subject + "/favoriteexercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }

        public async Task<bool> CreateFavoriteExercise(long exerciseId)
        {
            Request request = new Request(Method.POST, "patients/" + Token.Subject + "/favoriteexercises");
            request.Body["exercise_id"] = exerciseId;
            return await ExecuteAsync(request);
        }

        public async Task<bool> DeleteFavoriteExercise(long exerciseId)
        {
            Request request = new Request(Method.DELETE, "patients/" + Token.Subject + "/favoriteexercises/" + exerciseId);
            return await ExecuteAsync(request);
        }
    }
}
