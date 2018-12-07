using DizzyProject.BusinessLogic;
using DizzyProject.View;
using DizzyProxy.Exceptions;
using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            catch (ConnectionException)
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ConnectionException, AppResources.DialogOk);
            }
            catch (ApiException ex)
            {
                await DisplayAlert(ex.ErrorCode.ToString(), ex.Message, "OK");
            }
        }
    }
}