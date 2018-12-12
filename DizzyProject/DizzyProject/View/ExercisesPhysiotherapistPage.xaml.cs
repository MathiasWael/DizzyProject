using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;
using DizzyProxy.Resources;
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
	public partial class ExercisesPhysiotherapistPage : ContentPage
	{
		public ExercisesPhysiotherapistPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            try
            {
                ListViewExercises.ItemsSource = new List<ExerciseViewModel>(await new ExerciseController().GetGlobalExerciseViewModelsAsync());
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

        private async void ViewExercise_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewPhysiotherapistExercisePage((ExerciseViewModel)e.SelectedItem)));
        }

        private async void ToolbarAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CreateExercisePage()));
        }
    }
}