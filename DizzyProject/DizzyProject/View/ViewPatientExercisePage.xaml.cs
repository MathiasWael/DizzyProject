using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Models;
using DizzyProxy.Exceptions;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewPatientExercisePage : ContentPage
	{
        private ExerciseViewModel _selectedExercise;

		public ViewPatientExercisePage (ExerciseViewModel exercise)
		{
			InitializeComponent();
            _selectedExercise = exercise;
		}

        protected override async void OnAppearing()
        {
            try
            {
                ExerciseView.OnAppear(_selectedExercise);
            }
            catch (ApiException ex)
            {
                await DisplayAlert(AppResources.ErrorTitle, LogicHelper.ErrorMessage(ex.ErrorCode), AppResources.DialogOk);
            }
            catch (ConnectionException)
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ConnectionException, AppResources.DialogOk);
            }
        }

        private async void DoExercise_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DoExercisePage(_selectedExercise)));
        }
    }
}