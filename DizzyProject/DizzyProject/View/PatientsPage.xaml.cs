using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProxy.Models;

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
            patientController = new PatientController();
            patients = await patientController.GetAllPatientsAsync();
            ListViewPatients.ItemsSource = patients;
        }
    }
}