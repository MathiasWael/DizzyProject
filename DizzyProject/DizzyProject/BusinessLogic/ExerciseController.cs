using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.BusinessLogic
{
    public class ExerciseController
    {
        public List<Exercise> GetAllExercisesById(long userId)
        {
            List<Exercise> temp = new List<Exercise>();
            temp.AddRange(new CustomExercisePatientResource().GetCustomExercisesById(userId));
            temp.AddRange(new RecommendationResource().GetRecommendationsById(userId));
            temp.AddRange(new ExerciseFavoriteResource().GetFavoritesById(userId));
            temp.AddRange(new ExerciseResource().GetAllExercises());

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
