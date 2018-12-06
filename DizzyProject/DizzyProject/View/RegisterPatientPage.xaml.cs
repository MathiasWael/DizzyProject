using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProxy;
using DizzyProject.BusinessLogic;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using DizzyProxy.Exceptions;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPatientPage : ContentPage
    {
        private PatientController patientController;
        public RegisterPatientPage()
        {
            InitializeComponent();
            patientController = new PatientController();
        }

        private async void Submit_PressedAsync(object sender, EventArgs e)
        {

            if (Password1.Text != Password2.Text)
            {
                await DisplayAlert("Password mismatch", "Passwords do not match", "OK");
            }
            else
            {
                try
                {
                    Patient patient = await patientController.CreatePatientAsync(FirstName.Text, LastName.Text, Email.Text, Password1.Text);
                    await DisplayAlert("Success", "Account created", "OK");
                    Application.Current.MainPage = new MasterPage();
                }
                catch (ConnectionException)
                {
                    await DisplayAlert(AppResources.ApiErrorConnectionTitle, AppResources.ApiErrorConnectionDescription, AppResources.DialogOk);
                }
                catch (ApiException ex)
                {
                    await DisplayAlert(ex.ErrorCode.ToString(), ex.Message, "ok");
                }

            }
        }
    }
}