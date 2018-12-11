using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DizzyRegisterContentView : ContentView
	{
        public int? DizzyLevel;
        public Label DizzinessLevelLabel { get { return DizzyLevelLabel; } }
        public Slider DizzinessValueSlider { get { return dizzinessValue; } }
        public Editor DizzinessRegisterNote { get { return Note; } }

        public DizzyRegisterContentView ()
		{
			InitializeComponent ();
		}

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DizzyLevel = (int)Math.Round(e.NewValue);
            ((Slider)sender).Value = Math.Round(e.NewValue);
            DizzyLevelLabel.Text = ((Slider)sender).Value.ToString();
        }
    }
}