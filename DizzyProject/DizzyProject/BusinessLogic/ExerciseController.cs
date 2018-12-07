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
        private ExerciseResource _exerciseResource;
        private ExerciseFavoriteResource _exerciseFavoriteResource;
        private CustomExerciseResource _customExerciseResource;
        private RecommendationResource _recommendationResource;

        public ExerciseController()
        {
            _exerciseResource = new ExerciseResource();
            _exerciseFavoriteResource = new ExerciseFavoriteResource();
            _customExerciseResource = new CustomExerciseResource();
            _recommendationResource = new RecommendationResource();
        }

        public async Task<List<ExerciseViewModel>> GetAllExercisesByIdAsync()
        {
            List<ExerciseViewModel> viewModels = new List<ExerciseViewModel>();
            viewModels.AddRange(ConvertToViewModel(await _customExerciseResource.GetAllCustomExercisesAsync(Resource.UserId), ExerciseType.Custom));
            viewModels.AddRange(ConvertToViewModel(await _exerciseResource.GetAllExercisesAsync(), ExerciseType.Normal));

            List<Exercise> favoriteExercises = await _exerciseFavoriteResource.GetAllFavoriteExercisesAsync(Resource.UserId);
            foreach (Exercise favorite in favoriteExercises)
            {
                ExerciseViewModel ex = viewModels.Find(x => x.Id == favorite.Id);
                ex.Type = ExerciseType.Favorite;
            }

            List<Recommendation> recommendations = await _recommendationResource.GetAllRecommendationsAsync(Resource.UserId);
            foreach (Recommendation recommendation in recommendations)
            {
                ExerciseViewModel ex = viewModels.Find(x => x.Id == recommendation.ExerciseId);
                ex.Type = ExerciseType.Recommended;
                ex.Recommendation = recommendation;
            }

            return viewModels;
        }

        public List<ExerciseViewModel> ConvertToViewModel(List<Exercise> exercises, ExerciseType type)
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

        public async Task<ExerciseViewModel> GetExerciseViewModelByIdAsync(long exerciseId)
        {
            List<ExerciseViewModel> temp = await GetAllExercisesByIdAsync();
            return temp.Find(x => x.Id == exerciseId);
        }
    }
}
