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

        private void LogoTapped(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            ExerciseViewModel exercise = (ExerciseViewModel)image.BindingContext;
            if (exercise.Type == ExerciseType.Normal)
            {
                exerciseController.FavoriteExercise(exercise, 1); //temp id

                //temp code
                exercises.Remove(exercise);
                exercise.Type = ExerciseType.Favorite;
                exercises.Insert(6, exercise);
            }
            else if(exercise.Type == ExerciseType.Favorite)
            {
                exerciseController.UnfavoriteExercise(exercise, 1); //temp id
                
                //temp code
                exercises.Remove(exercise);
                exercise.Type = ExerciseType.Normal;
                exercises.Insert(12, exercise);
            }
        }

        private async void ViewExercise_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewExercisePage((Exercise)e.SelectedItem)));
        }
    }
}