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

		public LoginPage (string username, string password)
		{
			InitializeComponent();
            _controller = new LoginController();
            EmailEntry.Text = username;
            PasswordEntry.Text = password;
        }

        private async void CreateAccount(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegisterPatientPage()));
        }

        private async void Login_Pressed(object sender, EventArgs e)
        {
            try
            {
                User user = await _controller.Login(EmailEntry.Text, PasswordEntry.Text);
                Application.Current.MainPage = new MasterPage();
            }
            catch (ConnectionException)
            {
                await DisplayAlert(AppResources.ApiErrorConnectionTitle, AppResources.ApiErrorConnectionDescription, AppResources.DialogOk);
            }
            catch (ApiException ex)
            {
                switch (ex.ErrorCode)
                {
                    case 40: await DisplayAlert(AppResources.ApiError40Title, AppResources.ApiError40Description, AppResources.DialogOk); break;
                    case 41: await DisplayAlert(AppResources.ApiError41Title, AppResources.ApiError41Description, AppResources.DialogOk); break;
                    case 50: await DisplayAlert(AppResources.ApiError50Title, AppResources.ApiError50Description, AppResources.DialogOk); break;
                    default: await DisplayAlert(AppResources.ApiErrorDefaultTitle, AppResources.ApiErrorDefaultDescription, AppResources.DialogOk); break;
                }
            }
        }
    }
}