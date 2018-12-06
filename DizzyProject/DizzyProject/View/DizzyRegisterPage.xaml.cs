using DizzyProject.BusinessLogic;
using DizzyProxy.Models;
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
	public partial class DizzyRegisterPage : ContentPage
	{
        DizzinessController dc = new DizzinessController();

		public DizzyRegisterPage ()
		{
			InitializeComponent ();
		}

        private async void Submit_Pressed(object sender, EventArgs e)
        {
            Dizziness d;
            var answer = await DisplayAlert("Submit", "Are you sure you want to submit your answer?", "Yes", "No");
            if (answer)
            {
                d = await dc.SubmitAsync(Convert.ToInt32(DizzyView.DizzinessValueSlider.Value), DizzyView.DizzinessRegisterNote.Text);
            }
        }
    }
}