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
        public async Task<List<ExerciseViewModel>> GetAllExercisesById(long userId)
        {
            List<ExerciseViewModel> temp = new List<ExerciseViewModel>();
            temp.AddRange(convertToViewModel(await new CustomExercisePatientResource().GetAllCustomExercises(), ExerciseType.Custom));
            temp.AddRange(convertToViewModel(await new ExerciseFavoriteResource().GetAllFavoriteExercises(userId), ExerciseType.Favorite));
            temp.AddRange(convertToViewModel(await new ExerciseResource().GetAllExercises(), ExerciseType.Normal));

            List<Recommendation> recommendations = await new RecommendationResource().GetAllRecommendations();

            foreach (Recommendation recommendation in recommendations)
            {
                ExerciseViewModel ex = temp.Find(x => x.Id == recommendation.ExerciseId);
                if (ex != null)
                {
                    ex.Recommendation = recommendation;
                    ex.Type = ExerciseType.Recommended;
                }
            }
            temp.Sort((x, y) => x.Type.CompareTo(y.Type));
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

        public async Task<ExerciseViewModel> FavoriteExercise(ExerciseViewModel exerciseViewModel, long userId)
        {
            Exercise exercise = await new ExerciseFavoriteResource().CreateFavoriteExercise(userId, exerciseViewModel.Id);
            ExerciseViewModel exerciseVm = new ExerciseViewModel(exercise);
            exerciseVm.Type = ExerciseType.Favorite;
            return exerciseVm;
        }

        public ExerciseViewModel UnfavoriteExercise(ExerciseViewModel exercise)
        {
            return null;
        }
    }
}
