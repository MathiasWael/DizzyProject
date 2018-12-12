using DizzyProject.BusinessLogic;
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
	public partial class CreateExercisePage : ContentPage
	{
		public CreateExercisePage ()
		{
			InitializeComponent ();
		}

        private async void SubmitExerciseButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await new ExerciseController().CreateExerciseAsync(ExerciseNameEntry.Text, ExerciseDescriptionEditor.Text);
                await Navigation.PopModalAsync();
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