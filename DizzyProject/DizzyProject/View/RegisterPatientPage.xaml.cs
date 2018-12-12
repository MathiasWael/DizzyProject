using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProxy.Models;
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
}