using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.Model;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercisesPage : ContentPage
	{
        //List<Exercise> exercises = new List<Exercise>();
		public ExercisesPage ()
		{
			InitializeComponent ();
		}
	}
}