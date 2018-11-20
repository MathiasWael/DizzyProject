using DizzyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPatientPage : ContentPage
	{
        private string datePicked = "";
        private string genderPicked = "";
        List<Sex> genders;
		public RegisterPatientPage ()
		{
			InitializeComponent ();

            genders = new List<Sex>
            {
                new Sex{Gender = "Male"},
                new Sex{Gender = "Female"}
            };

            genderPicker.ItemsSource = genders;
        }

        private void DatePicker_OnDateSleceted(object sender, DateChangedEventArgs e)
        {
            datePicked = e.NewDate.ToString();
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
    }   
}