using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProxy.Exceptions;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewJournalEntryPage : ContentPage
	{
		public ViewJournalEntryPage()
		{
			InitializeComponent();
		}

        private async void SubmitJournalEntryButton_Clicked(object sender, EventArgs e)
        {

            try
            {
                await new JournalEntryController().CreateJournalEntryAsync(JournalEntryInputEditor.Text);
                await Navigation.PopModalAsync();
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
    }
}