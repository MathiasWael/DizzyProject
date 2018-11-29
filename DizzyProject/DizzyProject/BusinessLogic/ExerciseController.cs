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
        public async Task<List<ExerciseViewModel>> GetAllExercisesByIdAsync()
        {
            List<ExerciseViewModel> temp = new List<ExerciseViewModel>();
            temp.AddRange(ConvertToViewModel(await new CustomExercisePatientResource().GetAllCustomExercisesAsync(), ExerciseType.Custom));
            temp.AddRange(ConvertToViewModel(await new ExerciseResource().GetAllExercisesAsync(), ExerciseType.Normal));

            foreach (Exercise favorite in await new ExerciseFavoriteResource().GetAllFavoriteExercisesAsync())
            {
                ExerciseViewModel ex = temp.Find(x => x.Id == favorite.Id);
                ex.Type = ExerciseType.Favorite;
            }

            foreach (Recommendation recommendation in await new RecommendationResource().GetAllRecommendationsAsync())
            {
                ExerciseViewModel ex = temp.Find(x => x.Id == recommendation.ExerciseId);
                ex.Type = ExerciseType.Recommended;
                ex.Recommendation = recommendation;
            }
            return temp;
        }

        private List<ExerciseViewModel> ConvertToViewModel(List<Exercise> exercises, ExerciseType type)
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

        public async Task<bool> FavoriteExerciseAsync(ExerciseViewModel exerciseViewModel)
        {
            return await new ExerciseFavoriteResource().CreateFavoriteExerciseAsync(exerciseViewModel.Id);
        }

        public async Task<bool> UnfavoriteExerciseAsync(ExerciseViewModel exercise)
        {
            return await new ExerciseFavoriteResource().CreateFavoriteExerciseAsync(exercise.Id);
        }

        public async Task<Exercise> GetExerciseByIdAsync(long exerciseId)
        {
            return await new ExerciseResource().GetExerciseAsync(exerciseId);
        }
    }
}
