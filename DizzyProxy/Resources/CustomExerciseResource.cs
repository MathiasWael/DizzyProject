using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class CustomExerciseResource : Resource
    {
        public List<Exercise> GetAllCustomExercises(long userId) =>
            GetAllCustomExercisesAsync(userId).Result;

        public async Task<List<Exercise>> GetAllCustomExercisesAsync(long userId)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/customexercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }
    }
}