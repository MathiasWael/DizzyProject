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
	public partial class JournalPage : ContentPage
	{
        private JournalLogController journalLogController;
        private List<JournalLogViewModel> journalLogs;

        private enum SelectedTimeRange { ThisWeek, ThisMonth, Later }
        private SelectedTimeRange timeRange;

		public JournalPage ()
		{
			InitializeComponent();

            journalLogController = new JournalLogController();
		}

        protected async override void OnAppearing()
        {
            journalLogs = await journalLogController.getAllJournalLogsAsync();
            ListViewJournal.ItemsSource = journalLogController.getThisWeekJournals(journalLogs);
            timeRange = SelectedTimeRange.ThisWeek;
            ThisWeekButton.BackgroundColor = Color.FromHex("#3e83f2");
            ThisMonthButton.BackgroundColor = Color.LightBlue;
            LaterButton.BackgroundColor = Color.LightBlue;
        }

        private void WeekButton_Pressed(object sender, EventArgs args)
        {
            if(timeRange != SelectedTimeRange.ThisWeek)
            {
                ListViewJournal.ItemsSource = journalLogController.getThisWeekJournals(journalLogs);
                ThisWeekButton.BackgroundColor = Color.FromHex("#3e83f2");
                ThisMonthButton.BackgroundColor = Color.LightBlue;
                LaterButton.BackgroundColor = Color.LightBlue;
                timeRange = SelectedTimeRange.ThisWeek;
            }
        }

        private void MonthButton_Pressed(object sender, EventArgs args)
        {
            if (timeRange != SelectedTimeRange.ThisMonth)
            {
                ListViewJournal.ItemsSource = journalLogController.getThisMonthJournals(journalLogs);
                ThisWeekButton.BackgroundColor = Color.LightBlue;
                ThisMonthButton.BackgroundColor = Color.FromHex("#3e83f2");
                LaterButton.BackgroundColor = Color.LightBlue;
                timeRange = SelectedTimeRange.ThisMonth;
            }
        }

        private void LaterButton_Pressed(object sender, EventArgs args)
        {
            if (timeRange != SelectedTimeRange.Later)
            {
                ListViewJournal.ItemsSource = journalLogController.getLaterJournals(journalLogs);
                ThisWeekButton.BackgroundColor = Color.LightBlue;
                ThisMonthButton.BackgroundColor = Color.LightBlue;
                LaterButton.BackgroundColor = Color.FromHex("#3e83f2");
                timeRange = SelectedTimeRange.Later;
            }
        }

        private async void Journal_PressedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewJournalPage(((JournalLogViewModel)e.SelectedItem).Date)));
        }

        private async void ToolbarAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ViewJournalEntryPage()));
        }
    }
}