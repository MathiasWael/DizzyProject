using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class ExerciseResource : Resource
    {
        public List<Exercise> GetAllExercises() =>
            GetAllExercisesAsync().Result;

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            Request request = new Request(Method.GET, "exercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }

        public async Task<Exercise> GetExerciseAsync(long exerciseId)
        {
            Request request = new Request(Method.GET, $"exercises/{exerciseId}");
            return await ExecuteAsync<Exercise>(request);
        }
    }
}
