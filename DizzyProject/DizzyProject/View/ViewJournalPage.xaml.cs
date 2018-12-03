using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
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
    public partial class ViewJournalPage : ContentPage
    {
        private DateTime dateTime;
        public ViewJournalPage(DateTime dateTime)
        {
            InitializeComponent();

            this.dateTime = dateTime;
        }

        protected override async void OnAppearing()
        {
            List<JournalViewModel> journalViewModels = await new JournalController().GetAllJournalItemsAsync(dateTime);
            ListViewJournalItems.ItemsSource = journalViewModels;
        }

        private async void ExerciseLink_Tapped(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            await Navigation.PushModalAsync(new NavigationPage(new ViewExercisePage(((JournalViewModel)label.BindingContext).ExerciseViewModel)));
        }
    }
}