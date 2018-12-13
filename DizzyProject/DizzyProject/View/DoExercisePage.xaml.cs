using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;
using DizzyProxy.Models;

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
            try
            {
                await new DizzinessController().CreateDizzinessAsync(selectedExercise.Id, DizzyView.DizzyLevel, DizzyView.DizzinessRegisterNote.Text);
                await Navigation.PopModalAsync();
            }
            catch(ApiException ex)
            {
                await DisplayAlert(AppResources.ErrorTitle, LogicHelper.ErrorMessage(ex.ErrorCode), AppResources.DialogOk);
            }
            catch(ConnectionException)
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ConnectionException, AppResources.DialogOk);
            }
        }
    }
}