using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Models;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewExercisePage : ContentPage
	{
        private PhysiotherapistController _physiotherapistController;
        private Physiotherapist _physiotherapist;
        private ExerciseViewModel _selectedExercise;

		public ViewExercisePage (ExerciseViewModel exercise)
		{
			InitializeComponent();
            _selectedExercise = exercise;
            BindingContext = _selectedExercise;
            _physiotherapistController = new PhysiotherapistController();
		}

        protected override async void OnAppearing()
        {
            if (_selectedExercise.IsRecommended)
            {
                note.Text = _selectedExercise.Recommendation.Note;
                _physiotherapist = await _physiotherapistController.GetPhysiotherapistAsync(_selectedExercise.Recommendation.PhysiotherapistId);
                physName.Text = _physiotherapist.FullName;
            }
        }

        private async void DoExercise_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DoExercisePage(_selectedExercise)));
        }

        private async void BackButton_Pressed(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}