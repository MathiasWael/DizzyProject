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
	public partial class ViewExercisePage : ContentPage
	{
		public ViewExercisePage (Exercise exercise)
		{
			InitializeComponent ();
		}

        private async void Button_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ExercisesPage()));
        }
    }
}