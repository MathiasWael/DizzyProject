using DizzyProject.BusinessLogic;
using DizzyProxy.Exceptions;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DizzyProxy.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StepCountGraphPage : ContentPage
	{
		public StepCountGraphPage()
		{
			InitializeComponent();
		}

        protected async override void OnAppearing()
        {
            try
            {
                StepCountController stepCountController = new StepCountController();
                List<StepCount> stepCounts = await stepCountController.GetAllStepCountsAsync();

                PlotModel plotModel = new PlotModel();
                plotModel.Axes.Add(new LinearAxis { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, IsPanEnabled = false, Minimum = 0 });
                DateTime dateTime = DateTime.Today;
                plotModel.Axes.Add(new DateTimeAxis { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Position = AxisPosition.Bottom, Minimum = DateTimeAxis.ToDouble(dateTime.AddDays(-14)), Maximum = DateTimeAxis.ToDouble(dateTime) });

                LineSeries lineSeries = new LineSeries();
                lineSeries.Points.AddRange(stepCountController.GetStepCountDataPoints(stepCounts));
                plotModel.Series.Add(lineSeries);

                plotView.Model = plotModel;
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
    }
}