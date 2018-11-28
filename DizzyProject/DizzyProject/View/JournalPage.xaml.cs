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
	public partial class JournalPage : ContentPage
	{
        private JournalEntryController journalEntryController;
		public JournalPage ()
		{
			InitializeComponent();

            journalEntryController = new JournalEntryController();
		}

        protected override void OnAppearing()
        {
            journalEntryController.getAllJournalEntries();

            ListViewJournalsWeek.ItemsSource = journalEntryController.getThisWeekJournals();
            ListViewJournalsMonth.ItemsSource = journalEntryController.getThisMonthJournals();
            ListViewJournalsLater.ItemsSource = journalEntryController.getLaterJournals();
        }
    }
}