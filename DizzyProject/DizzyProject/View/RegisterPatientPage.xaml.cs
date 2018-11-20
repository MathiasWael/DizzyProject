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
		public RegisterPatientPage ()
		{
			InitializeComponent ();
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