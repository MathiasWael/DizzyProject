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

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPatientPage : ContentPage
    {
        private DateTime datePicked;
        private Sex sex;
        private Country country;
        private CountryController countryController;
        private PatientController patientController;
        public RegisterPatientPage()
        {
            InitializeComponent();

            countryController = new CountryController();
            List<Enum> sexes = new List<Enum>()
            {
                Sex.Female,
                Sex.Male
            };

            patientController = new PatientController();
            genderPicker.ItemsSource = sexes;
            CountryPicker.ItemsSource = countryController.getAllCountries();
        }

        private void DatePicker_OnDateSleceted(object sender, DateChangedEventArgs e)
        {
            datePicked = e.NewDate;
        }

        private void OnGenderChange(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                sex = (Sex)picker.ItemsSource[selectedIndex];
            }
        }

        private void OnCountryChange(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                country = (Country)picker.ItemsSource[selectedIndex];
            }
        }

        private async Task Submit_PressedAsync(object sender, EventArgs e)
        {
            if(Password1.Text != Password2.Text)
            {
                await DisplayAlert("Password mismatch", "Passwords do not match", "OK");
            }
            else
            {
                string h = Height.Text;
                short height = Convert.ToInt16(h);

                string w = Weight.Text;
                short weight = Convert.ToInt16(w);

                string z = ZipCode.Text;
                int zipCode = Convert.ToInt32(z);

                string c = City.Text;
                long city = Convert.ToInt64(c);

                Location location = new LocationController().CreateLocation(zipCode, Address.Text);
                Patient patient = patientController.CreatePatient(FirstName.Text, LastName.Text, Email.Text, Password1.Text);
                patientController.UpdatePatient(patient);
            }
        }
    }
}