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
		public DizzyRegisterPage ()
		{
			InitializeComponent ();
		}

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ((Slider)sender).Value = Math.Round(e.NewValue);
            DizzyLevelLabel.Text = ((Slider)sender).Value.ToString();
        }
    }
}