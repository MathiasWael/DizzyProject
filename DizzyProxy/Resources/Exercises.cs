using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class Exercises : Resource
    {
        public List<Exercise> GetAllExercises()
        {
            return new List<Exercise>()
            {
                new Exercise(),
            };
        }
    }
}
