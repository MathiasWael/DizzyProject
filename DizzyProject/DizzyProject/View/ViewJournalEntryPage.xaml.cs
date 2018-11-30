using DizzyProject.BusinessLogic;
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
	public partial class ViewJournalEntryPage : ContentPage
	{
		public ViewJournalEntryPage ()
		{
			InitializeComponent ();
		}

        private async void SubmitJournalEntryButton_Clicked(object sender, EventArgs e)
        {
            if(await new JournalEntryController().CreateJournalEntryAsync(JournalEntryInputEditor.Text))
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "No entry in journal found", "OK");
            }
        }
    }
}