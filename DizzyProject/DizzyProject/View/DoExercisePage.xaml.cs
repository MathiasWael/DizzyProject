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
	public partial class DoExercisePage : ContentPage
	{
        ExerciseViewModel selectedExercise;
		public DoExercisePage (ExerciseViewModel exercise)
		{
			InitializeComponent ();           
            selectedExercise = exercise;
            BindingContext = selectedExercise;

            reviewof.Text = "Review of " + selectedExercise.Name;
        }

        private async void Save_Pressed(object sender, EventArgs e)
        {
            //save logic stump
            //await Navigation.PushModalAsync(new NavigationPage(new DoExercisePage(selectedExercise)));
        }

        private async void BackButton_Pressed(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}