using DizzyProject.BusinessLogic;
using DizzyProxy.Exceptions;
using DizzyProxy.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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
	public partial class CombinedGraphPage : ContentPage
	{
		public CombinedGraphPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            DizzinessController dizzinessController = new DizzinessController();
            StepCountController stepCountController = new StepCountController();

            try
            {
                List<Dizziness> dizzinesses = await dizzinessController.GetAllDizzinessesWithLevelAsync();
                List<StepCount> stepCounts = await stepCountController.GetAllStepCountsAsync();

                PlotModel plotModel = new PlotModel();
                plotModel.Axes.Add(new LinearAxis { MajorGridlineStyle = LineStyle.Solid, IsPanEnabled = false, Position = AxisPosition.Left, Key = "DizzyLevelAxis" });
                plotModel.Axes.Add(new LinearAxis { MajorGridlineStyle = LineStyle.Solid, IsPanEnabled = false, Position = AxisPosition.Right, Key = "StepsAxis" });
                DateTime dateTime = DateTime.Today;
                plotModel.Axes.Add(new DateTimeAxis { MajorGridlineStyle = LineStyle.Solid, Position = AxisPosition.Bottom, Minimum = DateTimeAxis.ToDouble(dateTime.AddDays(-14)), Maximum = DateTimeAxis.ToDouble(dateTime) });

                LineSeries lineSeries = new LineSeries();
                lineSeries.Points.AddRange(dizzinessController.GetDizzinessDataPoints(dizzinesses));
                lineSeries.YAxisKey = "DizzyLevelAxis";
                plotModel.Series.Add(lineSeries);

                LineSeries lineSeries2 = new LineSeries();
                lineSeries2.Points.AddRange(stepCountController.GetStepCountDataPoints(stepCounts));
                lineSeries2.YAxisKey = "StepsAxis";
                plotModel.Series.Add(lineSeries2);

                plotView.Model = plotModel;
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

        private DataPoint DataPointStepCountConverter(StepCount stepCount)
        {
            return new DataPoint(DateTimeAxis.ToDouble(stepCount.Date), stepCount.Count);
        }
    }
}