using DizzyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProxy.Models;
using Sex = DizzyProxy.Models.Sex;
using DizzyProxy;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPatientPage : ContentPage
	{
        private DateTime datePicked;
        private string genderPicked = "";
        List<Sex> genders;
		public RegisterPatientPage ()
		{
			InitializeComponent ();

            genders = new List<Sex>
            {

            };

            genderPicker.ItemsSource = genders;
        }

        private void DatePicker_OnDateSleceted(object sender, DateChangedEventArgs e)
        {
            datePicked = e.NewDate;
        }

        void OnGenderChange(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                genderPicked = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void Submit_Pressed(object sender, EventArgs e)
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
                ZipCode = zipCode
            };

            Patient patient = new Patient
            {
                Created = DateTime.Now,
                Updated = DateTime.Now,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                PhoneNumber = PhoneNumber.Text,
                Weight = weight,
                Height = height,
                BirthDate = datePicked,
                //Sex = genderPicked,
                LocationId = location.Id,
            };
            //Patients.CreatePatientAsync();

        }
    }   
}