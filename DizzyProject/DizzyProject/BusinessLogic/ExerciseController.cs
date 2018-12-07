using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProject.ViewModels;
using DizzyProxy.Models;
using DizzyProxy.Resources;

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

        public async Task<List<ExerciseViewModel>> GetAllExerciseViewModelsAsync()
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
            List<ExerciseViewModel> viewModels = new List<ExerciseViewModel>();

            foreach (Exercise item in exercises)
            {
                ExerciseViewModel exerciseViewModel = new ExerciseViewModel(item);
                exerciseViewModel.Type = type;
                viewModels.Add(exerciseViewModel);
            }

            return viewModels;
        }

        public async Task<bool> FavoriteExerciseAsync(ExerciseViewModel exerciseViewModel)
        {
            return await _exerciseFavoriteResource.CreateFavoriteExerciseAsync(Resource.UserId, exerciseViewModel.Id);
        }

        public async Task<bool> UnfavoriteExerciseAsync(ExerciseViewModel exercise)
        {
            return await _exerciseFavoriteResource.DeleteFavoriteExerciseAsync(Resource.UserId, exercise.Id);
        }

        public async Task<Exercise> GetExerciseAsync(long exerciseId)
        {
            return await _exerciseResource.GetExerciseAsync(exerciseId);
        }

        public async Task<ExerciseViewModel> GetExerciseViewModelAsync(long exerciseId)
        {
            List<ExerciseViewModel> viewModels = await GetAllExerciseViewModelsAsync();
            return viewModels.Find(x => x.Id == exerciseId);
        }
    }
}