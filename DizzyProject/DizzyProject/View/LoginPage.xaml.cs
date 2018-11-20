using DizzyProject.View;
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
		public LoginPage ()
		{
			InitializeComponent();
        }

        private void LoginSuccess(object sender, EventArgs args)
        {
            Application.Current.MainPage = new MasterPage();
        }

        private async void CreateAccount(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegisterPatientPage()));
        }
	}
}