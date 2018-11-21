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
        public List<Exercise> GetAllExercises() //that is not custom = true
        {
            return new List<Exercise>()
            {
                new Exercise { Id = 1, AuthorId = 1, Name = "Exercise 1", Description="Exercise 1 Description",Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Normal},
                new Exercise { Id = 2, AuthorId = 1, Name = "Exercise 2", Description="Exercise 2 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Normal},
                new Exercise { Id = 3, AuthorId = 1, Name = "Exercise 3", Description="Exercise 3 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Normal},
                new Exercise { Id = 4, AuthorId = 1, Name = "Exercise 4", Description="Exercise 4 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Normal},
                new Exercise { Id = 5, AuthorId = 1, Name = "Exercise 5", Description="Exercise 5 Description", Created = DateTime.Now, Updated = DateTime.Now, Type = Models.Type.Normal},
            };
        }
    }
}
