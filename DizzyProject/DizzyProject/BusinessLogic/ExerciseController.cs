using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class ExerciseController
    {
        public async Task<List<Exercise>> GetAllExercisesById()
        {
            List<Exercise> temp = new List<Exercise>();
            try
            {
                temp.AddRange(await new CustomExercisePatientResource().GetAllCustomExercises());
                temp.AddRange(await new RecommendationResource().GetAllRecommendations());
                temp.AddRange(await new ExerciseFavoriteResource().GetAllFavoriteExercises());
                temp.AddRange(await new ExerciseResource().GetAllExercises());
            }
            
            catch(Exception e)
            {
                Exception t = e;
            }

            return temp;
        }

        public Exercise FavoriteExercise(Exercise exercise, long userId)
        {
            return new ExerciseFavoriteResource().FavoriteExercise(userId, exercise.Id);
        }

        public Exercise UnfavoriteExercise(Exercise exercise, long userId)
        {
            return new ExerciseFavoriteResource().UnfavoriteExercise(userId, exercise.Id);
        }
    }
}
