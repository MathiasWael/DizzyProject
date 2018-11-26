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
        private ObservableCollection<ExerciseViewModel> exercises;
		public ExercisesPage ()
		{
			InitializeComponent ();

            exerciseController = new ExerciseController();

            ListViewExercises.ItemsSource = exercises;
        }

        protected override async void OnAppearing()
        {
            exercises = new ObservableCollection<ExerciseViewModel>(await exerciseController.GetAllExercisesById());
        }

        private async void LogoTapped(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            ExerciseViewModel exercise = (ExerciseViewModel)image.BindingContext;
            if (exercise.Type == ExerciseType.Normal)
            {
                if(await exerciseController.FavoriteExercise(exercise))
                {
                    exercise.Type = ExerciseType.Favorite;
                    new ExerciseController().SortExercisesByType(exercises.ToList());
                }
            }
            else if(exercise.Type == ExerciseType.Favorite)
            {
                if (await exerciseController.UnfavoriteExercise(exercise))
                {
                    exercise.Type = ExerciseType.Normal;
                    new ExerciseController().SortExercisesByType(exercises.ToList());
                }
            }
        }

        private async void ViewExercise_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewExercisePage((Exercise)e.SelectedItem)));
        }
    }
}