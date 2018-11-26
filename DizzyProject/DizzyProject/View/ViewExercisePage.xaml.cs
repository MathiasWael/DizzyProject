using DizzyProject.ViewModels;
using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewExercisePage : ContentPage
	{
        Exercise selectedExercise;
		public ViewExercisePage (Exercise exercise)
		{
			InitializeComponent ();
            selectedExercise = exercise;

            ExerciseViewModel exercisev = new ExerciseViewModel(selectedExercise);

            if(exercisev.isRecommended)
            {
                note.Text = exercisev.Recommendation.Note;
                phy
            }
		}

        private async void DoExercise_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DoExercisePage(selectedExercise)));
        }

        private async void BackButton_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ExercisesPage()));
        }
    }
}