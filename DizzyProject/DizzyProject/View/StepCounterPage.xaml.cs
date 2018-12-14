using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepCounterPage : ContentPage
    {
        private IStepCounter _step;
        public IStepCounter Step
        {
            get
            {
                if (_step == null)
                    _step = DependencyService.Get<IStepCounter>();
                return _step;
            }
        }

        public StepCounterPage()
		{
			InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Step.StartSensor();
            Step.CountChanged += OnCountChanged;
        }

        private void OnCountChanged(object sender, EventArgs e)
        {
            StepsLabel.Text = Step.Count.ToString();
        }
    }
}