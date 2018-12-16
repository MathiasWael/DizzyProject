using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProxy.Models;
using DizzyProxy.Exceptions;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PatientsPage : ContentPage
	{
        private PatientController patientController;
        private List<Patient> patients;

        public PatientsPage()
        {
            InitializeComponent();
            patientController = new PatientController();
        }

        protected override async void OnAppearing()
        {
            try
            {
            patientController = new PatientController();
            patients = await patientController.GetAllPatientsAsync();
            ListViewPatients.ItemsSource = patients;
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

        private async void ViewPatient_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            Patient patient = (Patient)e.SelectedItem;
            await Navigation.PushModalAsync(new NavigationPage(new JournalPage(patient.Id)));
        }
    }
}