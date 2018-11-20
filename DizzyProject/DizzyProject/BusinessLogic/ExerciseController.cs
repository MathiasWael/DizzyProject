using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.BusinessLogic
{
    public class ExerciseController
    {
        ExerciseResource ExerciseResource;
        ExerciseFavoriteResource ExerciseFavoriteResource;
        CustomExercisePatientResource CustomExercisePatientResource;
        RecommendationResource RecommendationResource;

        public List<Exercise> GetAllExercisesById(long userId)
        {
            ExerciseResource = new ExerciseResource();
            ExerciseFavoriteResource = new ExerciseFavoriteResource();
            CustomExercisePatientResource = new CustomExercisePatientResource();
            RecommendationResource = new RecommendationResource();

            List<Exercise> temp = new List<Exercise>();
            temp.AddRange(CustomExercisePatientResource.GetCustomExercisesById(userId));
            temp.AddRange(RecommendationResource.GetRecommendationsById(userId));
            temp.AddRange(ExerciseFavoriteResource.GetFavoritesById(userId));
            temp.AddRange(ExerciseResource.GetAllExercises());

            return temp;
        }
    }
}
