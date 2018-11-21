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
        public List<CustomExercise> GetCustomExercisesById(long userId)
        {
            return new List<CustomExercise>()
            {
                new CustomExercise { Id = 9, AuthorId = 1, Name = "Exercise Custom 1", Description="Exercise Custom 1 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Custom },
                new CustomExercise { Id = 10, AuthorId = 2, Name = "Exercise Custom 2", Description="Exercise Custom 2 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Custom },
                new CustomExercise { Id = 11, AuthorId = 3, Name = "Exercise Custom 3", Description="Exercise Custom 3 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Custom },
            };
        }
    }
}
