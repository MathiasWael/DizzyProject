﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProject.BusinessLogic;
using DizzyProject.ViewModels;
using DizzyProxy.Exceptions;

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
            try
            {
                journalLogs = await journalLogController.getAllJournalLogsAsync();
                ListViewJournal.ItemsSource = journalLogController.getThisWeekJournals(journalLogs);
                timeRange = SelectedTimeRange.ThisWeek;
                ThisWeekButton.BackgroundColor = Color.FromHex("#2f89cc");
                ThisMonthButton.BackgroundColor = Color.FromHex("#82b8e0");
                LaterButton.BackgroundColor = Color.FromHex("#82b8e0");
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

        private void WeekButton_Pressed(object sender, EventArgs args)
        {
            if(timeRange != SelectedTimeRange.ThisWeek)
            {
                ListViewJournal.ItemsSource = journalLogController.getThisWeekJournals(journalLogs);
                ThisWeekButton.BackgroundColor = Color.FromHex("#2f89cc");
                ThisMonthButton.BackgroundColor = Color.FromHex("#82b8e0");
                LaterButton.BackgroundColor = Color.FromHex("#82b8e0");
                timeRange = SelectedTimeRange.ThisWeek;
            }
        }

        private void MonthButton_Pressed(object sender, EventArgs args)
        {
            if (timeRange != SelectedTimeRange.ThisMonth)
            {
                ListViewJournal.ItemsSource = journalLogController.getThisMonthJournals(journalLogs);
                ThisWeekButton.BackgroundColor = Color.FromHex("#82b8e0");
                ThisMonthButton.BackgroundColor = Color.FromHex("#2f89cc");
                LaterButton.BackgroundColor = Color.FromHex("#82b8e0");
                timeRange = SelectedTimeRange.ThisMonth;
            }
        }

        private void LaterButton_Pressed(object sender, EventArgs args)
        {
            if (timeRange != SelectedTimeRange.Later)
            {
                ListViewJournal.ItemsSource = journalLogController.getLaterJournals(journalLogs);
                ThisWeekButton.BackgroundColor = Color.FromHex("#82b8e0");
                ThisMonthButton.BackgroundColor = Color.FromHex("#82b8e0");
                LaterButton.BackgroundColor = Color.FromHex("#2f89cc");
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