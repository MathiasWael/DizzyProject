using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProject.View;
using DizzyProxy.Exceptions;
using DizzyProxy.Models;

namespace DizzyProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private LoginController _controller = new LoginController();

        public LoginPage ()
		{
			InitializeComponent();
            _controller = new LoginController();
        }

        private async void CreateAccount(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegisterPatientPage()));
        }

        private async void Login_Pressed(object sender, EventArgs e)
        {
            try
            {
                User user = await _controller.LoginAsync(EmailEntry.Text, PasswordEntry.Text);
                Application.Current.MainPage = new MasterPage();
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