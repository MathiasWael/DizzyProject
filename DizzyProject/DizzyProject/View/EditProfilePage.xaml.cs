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
using DizzyProject.ViewModels;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        private DateTime datePicked;
        private Sex sex;
        private CountryController countryController;
        private CityController cityController;
        private PatientController patientController;
        private PatientViewModel patientViewModel;
        private Patient patient;
        private Country country;
        private City city;
        public EditProfilePage()
        {
            InitializeComponent();
            countryController = new CountryController();
            cityController = new CityController();
            patientController = new PatientController();
            country = new Country();
            city = new City();
        }

        protected override async void OnAppearing()
        {
            List<Enum> sexes = new List<Enum>()
            {
                Sex.Female,
                Sex.Male
            };
            genderPicker.ItemsSource = sexes;
            CountryPicker.ItemsSource = await countryController.GetAllCountriesAsync();
            patient = await patientController.GetPatientAsync(Resource.Token.Subject);
            patientViewModel = new PatientViewModel(patient);
            sex = (Sex)patientViewModel.Sex;
            BindingContext = patientViewModel;

            if (patient.ZipCode != null)
            {
                ZipCode.Placeholder = patient.ZipCode.ToString();
            }
            if (patient.Address != null)
            {
                Address.Placeholder = patient.Address;
            }
            if (patient.ZipCode != null && patient.CountryCode != null)
            {
                city = await cityController.GetCityAsync(patient.ZipCode, patient.CountryCode);
                City.Text = city.Name;
            }
            if (patient.CountryCode != null)
            {
                country = await countryController.GetCountryAsync(patient.CountryCode);
                CountryPicker.Title = country.Name;
            }
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

        private async void Edit_PressedAsync(object sender, EventArgs e)
        {
            string h = Height.Text;
            short height = Convert.ToInt16(h);

            string w = Weight.Text;
            short weight = Convert.ToInt16(w);

            if (CurrentPassword.Text != null || NewPassword.Text != null || NewPassword2 != null)
            {
                if (NewPassword.Text != NewPassword2.Text || CurrentPassword.Text == null)
                {
                    await DisplayAlert("Password error", "Passwords do not match or you're missing a field", "OK");
                }
                else
                {
                    try
                    {
                        //Zip
                        if (ZipCode.Text != null)
                        {
                            patient.ZipCode = ZipCode.Text;
                        }

                        //Address
                        if (Address.Text != null)
                        {
                            patient.Address = Address.Text;
                        }

                        //Phone
                        if (PhoneNumber.Text != null)
                        {
                            patient.Phone = PhoneNumber.Text;
                        }

                        //Height
                        if (Height.Text != null)
                        {
                            patient.Height = height;
                        }

                        //Weight
                        if (Weight.Text != null)
                        {
                            patient.Weight = weight;
                        }
                        patient.BirthDate = datePicked;
                        patient.Sex = sex;
                        patient.CountryCode = country.Code;
                        await patientController.UpdatePatientAsync(patient, CurrentPassword.Text, NewPassword.Text);
                        await DisplayAlert("Success", "Profile updated", "OK");
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
    }
}