using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProxy.Exceptions;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DizzyRegisterPage : ContentPage
	{
		public DizzyRegisterPage ()
		{
			InitializeComponent ();
		}

        private async void Submit_Pressed(object sender, EventArgs e)
        {
            try
            {
                bool answer = await DisplayAlert("Submit", "Are you sure you want to submit your answer?", "Yes", "No");
                if (answer)
                {
                    await new DizzinessController().CreateDizzinessAsync(null, DizzyView.DizzyLevel, DizzyView.DizzinessRegisterNote.Text);
                }
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