using DizzyProject.Model;
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

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPatientPage : ContentPage
    {
        private DateTime datePicked;
        private Sex sex;
        private Country country;
        private CountryController countryController;
        private PatientResource patientResource;
        public RegisterPatientPage()
        {
            InitializeComponent();

            countryController = new CountryController();
            List<Enum> sexes = new List<Enum>()
            {
                Sex.Female,
                Sex.Male
            };

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
            bool success = false;
            string password1 = Password1.Text;
            string password2 = Password2.Text;

            if(password1 != password2)
            {
                await DisplayAlert("Password mismatch", "Passwords do not match", "OK");
            }
            else
            {
                success = true;
            }

            if(success == true)
            {
                string h = Height.Text;
                short height = Convert.ToInt16(h);

                string w = Weight.Text;
                short weight = Convert.ToInt16(w);

                string z = ZipCode.Text;
                int zipCode = Convert.ToInt32(z);

                string c = City.Text;
                long city = Convert.ToInt64(c);

                Location location = new Location
                {
                    Address = Address.Text,
                    CityId = city,
                    ZipCode = zipCode,
                    CountryId = country.Id
                };

                Patient patient = new Patient
                {
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Email = Email.Text,
                    Phone = PhoneNumber.Text,
                    Weight = weight,
                    Height = height,
                    BirthDate = datePicked,
                    Sex = sex,
                    LocationId = location.Id
                };

                await patientResource.CreatePatientAsync(patient.FirstName, patient.LastName, patient.Email, password1);
            }
        }
    }
}