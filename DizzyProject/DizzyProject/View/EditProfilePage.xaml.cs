﻿using System;
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
        private Country country;
        private CountryController countryController;
        private PatientController patientController;
        private LocationController locationController;
        private PatientViewModel patientViewModel;
        private Patient patient;
        private Location location;
        public EditProfilePage()
        {
            InitializeComponent();
            country = new Country();
            countryController = new CountryController();
            patientController = new PatientController();
            locationController = new LocationController();           
        }

        protected override async void OnAppearing()
        {            
            List<Enum> sexes = new List<Enum>()
            {
                Sex.Female,
                Sex.Male
            };
            genderPicker.ItemsSource = sexes;
            CountryPicker.ItemsSource = countryController.getAllCountries();
            patient = await patientController.GetPatientAsync(Resource.Token.Subject);
            patientViewModel = new PatientViewModel(patient);
            BindingContext = patientViewModel;

            if (patient.LocationId != null)
            {
                location = await locationController.GetLocationAsync(patient.LocationId);
                ZipCode.Placeholder = location.ZipCode.ToString();
                Address.Placeholder = location.Address;
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

            string z = ZipCode.Text;
            int zipCode = Convert.ToInt32(z);

            string c = City.Text;
            long city = Convert.ToInt64(c);

            if (Password1.Text != Password2.Text)
            {
                await DisplayAlert("Password mismatch", "Passwords do not match", "OK");
            }
            else
            {
                try
                {
                    if (ZipCode.Text != "" && Address.Text != "" && country.Code != "")
                    {
                        if(patient.LocationId == null)
                        {
                            location = await locationController.CreateLocationAsync(zipCode, country.Code, Address.Text);
                        }
                        else
                        {
                            location = await locationController.UpdateLocation(location);
                        }
                    }
                    else if (ZipCode.Text == "" || Address.Text == "" || country.Code == "")
                    {
                        await DisplayAlert("Location fail", "Fill in all the location settings", "OK");
                    }
                    
                    patient.LocationId = location.Id;   
                    patient.BirthDate = datePicked;
                    patient.Sex = sex;
                    patient.Phone = PhoneNumber.Text;
                    patient.Updated = DateTime.Now;
                    await patientController.UpdatePatientAsync(patient, Password1.Text);
                    await DisplayAlert("Success", "Profile updated","OK");
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