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
                new Exercise { Id = 1, AuthorId = 1, Name = "Exercise 1", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 2, AuthorId = 1, Name = "Exercise 2", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 3, AuthorId = 1, Name = "Exercise 3", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 4, AuthorId = 1, Name = "Exercise 4", Created = DateTime.Now, Updated = DateTime.Now },
                new Exercise { Id = 5, AuthorId = 1, Name = "Exercise 5", Created = DateTime.Now, Updated = DateTime.Now },
            };
        }
    }
}
