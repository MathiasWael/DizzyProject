using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
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
        PhysiotherapistController physC;
        Physiotherapist phys;
        ExerciseViewModel selectedExercise;
		public ViewExercisePage (ExerciseViewModel exercise)
		{
			InitializeComponent ();
            selectedExercise = exercise;
                       

            if (selectedExercise.isRecommended)
            {
                note.Text = selectedExercise.Recommendation.Note;
                physName.Text = phys.FullName;
            }
		}

        protected override async void OnAppearing()
        {
            phys = await physC.GetPhysioById(selectedExercise.Recommendation.PhysiotherapistId);
        }

        private async void DoExercise_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DoExercisePage(selectedExercise)));
        }

        private async void BackButton_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ExercisesPage()));
        }
    }
}