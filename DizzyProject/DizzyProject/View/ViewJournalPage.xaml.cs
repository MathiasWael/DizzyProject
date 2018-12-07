using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewJournalPage : ContentPage
    {
        private DateTime _dateTime;

        public ViewJournalPage(DateTime dateTime)
        {
            InitializeComponent();
            _dateTime = dateTime;
        }

        protected override async void OnAppearing()
        {
            try
            {
                List<JournalViewModel> journalViewModels = await new JournalController().GetAllJournalItemsAsync(_dateTime);
                ListViewJournalItems.ItemsSource = journalViewModels;
            }
            catch (ApiException ex)
            {
                await DisplayAlert(AppResources.ErrorTitle, ErrorHandling.ErrorMessage(ex.ErrorCode), AppResources.DialogOk);
            }
            catch (ConnectionException)
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ConnectionException, AppResources.DialogOk);
            }
        }

        private async void ExerciseLink_Tapped(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            await Navigation.PushModalAsync(new NavigationPage(new ViewExercisePage(((JournalViewModel)label.BindingContext).ExerciseViewModel)));
        }
    }
}