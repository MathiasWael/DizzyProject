using DizzyProject.BusinessLogic;
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

            reviewof.Text = "Review of " + selectedExercise.Name;
        }

        private async void Save_Pressed(object sender, EventArgs e)
        {
            if (await new DizzinessController().CreateDizzinessAsync(DizzyView.DizzyLevel, DizzyView.DizzinessRegisterNote.Text, selectedExercise.Id))
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong", "OK");
            }
        }
    }
}