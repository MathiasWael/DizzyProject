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
        public async Task<List<Exercise>> GetAllExercises()
        {
            Request request = new Request(Method.GET, "exercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }
    }
}
