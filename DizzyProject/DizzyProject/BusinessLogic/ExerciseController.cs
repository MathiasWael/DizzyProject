using DizzyProject.ViewModels;
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
        public async Task<List<ExerciseViewModel>> GetAllExercisesById()
        {
            List<ExerciseViewModel> temp = new List<ExerciseViewModel>();
            temp.AddRange(convertToViewModel(await new CustomExercisePatientResource().GetAllCustomExercises(), ExerciseType.Custom));
            temp.AddRange(convertToViewModel(await new ExerciseResource().GetAllExercises(), ExerciseType.Normal));

            foreach (Exercise favorite in await new ExerciseFavoriteResource().GetAllFavoriteExercises())
            {
                ExerciseViewModel ex = temp.Find(x => x.Id == favorite.Id);
                ex.Type = ExerciseType.Favorite;
            }

            foreach (Recommendation recommendation in await new RecommendationResource().GetAllRecommendations())
            {
                ExerciseViewModel ex = temp.Find(x => x.Id == recommendation.ExerciseId);
                ex.Type = ExerciseType.Recommended;
                ex.Recommendation = recommendation;
            }
            return temp;
        }

        private List<ExerciseViewModel> convertToViewModel(List<Exercise> exercises, ExerciseType type)
        {
            List<ExerciseViewModel> temp = new List<ExerciseViewModel>();
            foreach (Exercise item in exercises)
            {
                ExerciseViewModel exerciseViewModel = new ExerciseViewModel(item);
                exerciseViewModel.Type = type;
                temp.Add(exerciseViewModel);
            }
            return temp;
        }

        public async Task<bool> FavoriteExercise(ExerciseViewModel exerciseViewModel)
        {
            return await new ExerciseFavoriteResource().CreateFavoriteExercise(exerciseViewModel.Id);
        }

        public async Task<bool> UnfavoriteExercise(ExerciseViewModel exercise)
        {
            return await new ExerciseFavoriteResource().CreateFavoriteExercise(exercise.Id);
        }
    }
}
