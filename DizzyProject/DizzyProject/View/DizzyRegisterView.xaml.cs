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
	public partial class DizzyRegisterView : ContentView
	{
		public DizzyRegisterView ()
		{
			InitializeComponent ();
		}

        public Label DizzinessLevelLabel { get { return DizzyLevelLabel; } }
        public Slider DizzinessValueSlider { get { return dizzinessValue; } }
        public Editor DizzinessRegisterNote { get { return Note; } }
        public int? DizzyLevel;

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DizzyLevel = (int)Math.Round(e.NewValue);
            ((Slider)sender).Value = Math.Round(e.NewValue);
            DizzyLevelLabel.Text = ((Slider)sender).Value.ToString();
        }
    }
}