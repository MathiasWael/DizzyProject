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
        public List<CustomExercise> GetCustomExercisesById()
        {
            return new List<CustomExercise>()
            {
                new CustomExercise { Id = 9, AuthorId = 1, Name = "Exercise Custom 1", Created = DateTime.Now, Updated = DateTime.Now },
                new CustomExercise { Id = 10, AuthorId = 2, Name = "Exercise Custom 2", Created = DateTime.Now, Updated = DateTime.Now },
                new CustomExercise { Id = 11, AuthorId = 3, Name = "Exercise Custom 3", Created = DateTime.Now, Updated = DateTime.Now },
            };
        }
    }
}
