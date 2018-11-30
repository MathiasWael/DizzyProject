using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.ViewModels;
using DizzyProxy.Models;
using DizzyProject.BusinessLogic;
using System.Collections.ObjectModel;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercisesPage : ContentPage
	{
        private ExerciseController exerciseController;
        private List<ExerciseViewModel> exercises;
		public ExercisesPage ()
		{
			InitializeComponent ();

            exerciseController = new ExerciseController();
        }

        protected override async void OnAppearing()
        {
            exercises = new List<ExerciseViewModel>(await exerciseController.GetAllExercisesByIdAsync());
            SortAndRefresh();
        }

        private void SortAndRefresh()
        {
            exercises.Sort((x, y) => x.Type.CompareTo(y.Type));
            ListViewExercises.ItemsSource = null;
            ListViewExercises.ItemsSource = exercises;
        }

        private async void LogoTapped(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            ExerciseViewModel exercise = (ExerciseViewModel)image.BindingContext;
            if (exercise.Type == ExerciseType.Normal)
            {
                if(await exerciseController.FavoriteExerciseAsync(exercise))
                {
                    exercise.Type = ExerciseType.Favorite;
                    SortAndRefresh();
                }
            }
            else if(exercise.Type == ExerciseType.Favorite)
            {
                if (await exerciseController.UnfavoriteExerciseAsync(exercise))
                {
                    exercise.Type = ExerciseType.Normal;
                    SortAndRefresh();
                }
            }
        }

        private async void ViewExercise_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewExercisePage((ExerciseViewModel)e.SelectedItem)));
        }
    }
}