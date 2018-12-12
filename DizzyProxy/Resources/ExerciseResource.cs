using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

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

        public Exercise GetExercise(long exerciseId) =>
            GetExerciseAsync(exerciseId).Result;

        public async Task<Exercise> GetExerciseAsync(long exerciseId)
        {
            Request request = new Request(Method.GET, $"exercises/{exerciseId}");
            return await ExecuteAsync<Exercise>(request);
        }

        public Exercise CreateExercise(string exerciseName, string exerciseDescription) =>
            CreateExerciseAsync(exerciseName, exerciseDescription).Result;

        public async Task<Exercise> CreateExerciseAsync(string exerciseName, string exerciseDescription)
        {
            Request request = new Request(Method.POST, $"exercises");
            request.Body["exercise_name"] = exerciseName;
            request.Body["exercise_description"] = exerciseDescription;
            request.Body["author_id"] = UserId;
            return await ExecuteAsync<Exercise>(request);
        }
    }
}