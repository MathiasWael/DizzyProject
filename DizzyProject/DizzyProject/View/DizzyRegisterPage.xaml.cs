using DizzyProject.BusinessLogic;
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
                    await new DizzinessController().CreateDizzinessAsync(DizzyView.DizzyLevel, DizzyView.DizzinessRegisterNote.Text, null);
                }
            }
            catch (ApiException ex)
            {
                await DisplayAlert(AppResources.ErrorTitle, ErrorHandling.ErrorMessage(ex.ErrorCode), AppResources.DialogOk);
            }
            catch (ConnectionException)
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ConnectionException, AppResources.DialogOk);
            }
        }
    }
}