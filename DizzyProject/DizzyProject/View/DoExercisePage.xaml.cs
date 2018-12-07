using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;
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
            try
            {
                if(await new DizzinessController().CreateDizzinessAsync(DizzyView.DizzyLevel, DizzyView.DizzinessRegisterNote.Text, selectedExercise.Id))
                {
                    await Navigation.PopModalAsync();
                }
            }
            catch(ApiException ex)
            {
                await DisplayAlert(AppResources.ErrorTitle, ErrorHandling.ErrorMessage(ex.ErrorCode), AppResources.DialogOk);
            }
            catch(ConnectionException)
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ConnectionException, AppResources.DialogOk);
            }
        }
    }
}