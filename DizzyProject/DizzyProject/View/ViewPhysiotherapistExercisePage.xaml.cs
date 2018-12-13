using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;
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
	public partial class ViewPhysiotherapistExercisePage : ContentPage
	{
        private ExerciseViewModel _selectedExercise;

        public ViewPhysiotherapistExercisePage (ExerciseViewModel exercise)
		{
			InitializeComponent ();
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
    }
}