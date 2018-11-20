using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.Model;
using DizzyProxy.Models;
using DizzyProject.BusinessLogic;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercisesPage : ContentPage
	{
        private ExerciseController exerciseController; 
        List<Exercise> exercises;
		public ExercisesPage ()
		{
			InitializeComponent ();

            exerciseController = new ExerciseController();

            exercises = exerciseController.GetAllExercisesById(1); //temp user id

            ListViewExercises.ItemsSource = exercises;


        }
	}
}