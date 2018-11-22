using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using System.Collections.ObjectModel;
using DizzyProxy.Models;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PatientsPage : ContentPage
	{
        private PatientController patientController;
        private ObservableCollection<Patient> patients;
        public PatientsPage()
        {
            InitializeComponent();

            patientController = new PatientController();
            patients = new ObservableCollection<Patient>(patientController.GetAllPatients(//id for den physioterapeut der er logget ind ));

            ListViewPatients.ItemsSource = patients;
        }
    }
}