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
        public List<Exercise> GetAllFavoriteExercises() =>
            GetAllFavoriteExercisesAsync().Result;

        public async Task<List<Exercise>> GetAllFavoriteExercisesAsync() 
        {
            Request request = new Request(Method.GET, "patients/"+ Token.Subject + "/favoriteexercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }

        public bool CreateFavoriteExercise(long exerciseId) =>
            CreateFavoriteExerciseAsync(exerciseId).Result;

        public async Task<bool> CreateFavoriteExerciseAsync(long exerciseId)
        {
            Request request = new Request(Method.POST, "patients/" + Token.Subject + "/favoriteexercises");
            request.Body["exercise_id"] = exerciseId;
            return await ExecuteAsync(request);
        }

        public bool DeleteFavoriteExercise(long exerciseId) =>
            DeleteFavoriteExerciseAsync(exerciseId).Result;

        public async Task<bool> DeleteFavoriteExerciseAsync(long exerciseId)
        {
            Request request = new Request(Method.DELETE, "patients/" + Token.Subject + "/favoriteexercises/" + exerciseId);
            return await ExecuteAsync(request);
        }
    }
}