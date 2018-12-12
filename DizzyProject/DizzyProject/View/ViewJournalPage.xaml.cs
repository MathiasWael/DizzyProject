using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;
using DizzyProxy.Resources;

namespace DizzyProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewJournalPage : ContentPage
    {
        private List<JournalViewModel> _journalViewModels;
        private DateTime _dateTime;
        private long? _patientId;

        public ViewJournalPage(DateTime dateTime, long? patientId)
        {
            InitializeComponent();
            _dateTime = dateTime;
            _patientId = patientId;
        }

        protected override async void OnAppearing()
        {
            try
            {
                _journalViewModels = await new JournalController().GetAllJournalItemsAsync(_dateTime, _patientId);
                ListViewJournalItems.ItemsSource = _journalViewModels;
            }
            catch (ApiException ex)
            {
                await DisplayAlert(AppResources.ErrorTitle, LogicHelper.ErrorMessage(ex.ErrorCode), AppResources.DialogOk);
            }
            catch (ConnectionException)
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ConnectionException, AppResources.DialogOk);
            }
        }

        private async void ExerciseLink_Tapped(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if(Resource.Token.UserType == DizzyProxy.Models.UserType.Patient ) await Navigation.PushModalAsync(new NavigationPage(new ViewPatientExercisePage(((JournalViewModel)label.BindingContext).ExerciseViewModel)));
            else if(Resource.Token.UserType == DizzyProxy.Models.UserType.Physiotherapist) await Navigation.PushModalAsync(new NavigationPage(new ViewPhysiotherapistExercisePage(((JournalViewModel)label.BindingContext).ExerciseViewModel)));
        }
    }
}