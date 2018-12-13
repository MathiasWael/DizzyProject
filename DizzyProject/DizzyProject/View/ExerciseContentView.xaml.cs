using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;
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
    public partial class ExerciseContentView : ContentView
    {
        public ExerciseContentView()
        {
            InitializeComponent();
        }

        public async void OnAppear(ExerciseViewModel exercise)
        {
            BindingContext = exercise;
            if (exercise.IsRecommended)
            {
                note.Text = exercise.Recommendation.Note;
                Physiotherapist physiotherapist = await new PhysiotherapistController().GetPhysiotherapistAsync(exercise.Recommendation.PhysiotherapistId);
                physName.Text = physiotherapist.FullName;
            }
        }
    }
}