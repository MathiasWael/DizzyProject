using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepCounterPage : ContentPage
    {
        private IStep _step;
        public IStep Step
        {
            get
            {
                if (_step == null)
                    _step = DependencyService.Get<IStep>();
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

            Step.Connect();
            Step.CountChanged += OnCountChanged;

            if (Step.Count != null)
            {
                Steps.Text = Step.Count.ToString();
            }
        }

        private void OnCountChanged(object sender, EventArgs e)
        {
            Steps.Text = Step.Count.ToString();
        }
    }
}