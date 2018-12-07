using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class ExerciseFavoriteResource : Resource
    {
        public List<Exercise> GetAllFavoriteExercises(long userId) =>
            GetAllFavoriteExercisesAsync(userId).Result;

        public async Task<List<Exercise>> GetAllFavoriteExercisesAsync(long userId) 
        {
            Request request = new Request(Method.GET, $"patients/{userId}/favoriteexercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }

        public bool CreateFavoriteExercise(long userId, long exerciseId) =>
            CreateFavoriteExerciseAsync(userId, exerciseId).Result;

        public async Task<bool> CreateFavoriteExerciseAsync(long userId, long exerciseId)
        {
            Request request = new Request(Method.POST, $"patients/{userId}/favoriteexercises");
            request.Body["exercise_id"] = exerciseId;
            return await ExecuteAsync(request);
        }

        public bool DeleteFavoriteExercise(long userId, long exerciseId) =>
            DeleteFavoriteExerciseAsync(userId, exerciseId).Result;

        public async Task<bool> DeleteFavoriteExerciseAsync(long userId, long exerciseId)
        {
            Request request = new Request(Method.DELETE, $"patients/{userId}/favoriteexercises/{exerciseId}");
            return await ExecuteAsync(request);
        }
    }
}