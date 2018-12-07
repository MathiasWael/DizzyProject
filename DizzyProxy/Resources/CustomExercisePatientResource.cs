using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class CustomExercisePatientResource : Resource
    {
        public async Task<List<Exercise>> GetAllCustomExercisesAsync()
        {
            Request request = new Request(Method.GET, "patients/" + Token.Subject + "/customexercises");
            return await ExecuteAsync<List<Exercise>>(request);
        }
    }
}
