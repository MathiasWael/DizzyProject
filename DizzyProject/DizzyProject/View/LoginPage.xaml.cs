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
                User user = await _controller.Login(EmailEntry.Text, PasswordEntry.Text);
            }
            catch (ConnectionException)
            {
                await DisplayAlert("Service Unreachable", "The service could not be reached, please check your connection.", "Ok");
            }
            catch (ApiException ex)
            {
                switch (ex.ErrorCode)
                {
                    case 40: await DisplayAlert("Validation Error", "Input does not match validation criteria.", "Ok"); break;
                    case 41: await DisplayAlert("Input Error", "Invalid email or password.", "Ok"); break;
                    case 50: await DisplayAlert("Service Error", "Internal server error.", "Ok"); break;
                    default: await DisplayAlert("Service Error", "Unhandled service error.", "Ok"); break;
                }
            }
        }
    }
}