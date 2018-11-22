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
	public partial class DoExercisePage : ContentPage
	{
        Exercise selectedExercise;
		public DoExercisePage (Exercise exercise)
		{
			InitializeComponent ();
            selectedExercise = exercise;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ((Slider)sender).Value = Math.Round(e.NewValue);
            DizzyLevelLabel.Text = ((Slider)sender).Value.ToString();
        }

        private async void Save_Pressed(object sender, EventArgs e)
        {
            //save logic stump
            //await Navigation.PushModalAsync(new NavigationPage(new DoExercisePage(selectedExercise)));
        }

        private async void BackButton_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewExercisePage(selectedExercise)));
        }
    }
}