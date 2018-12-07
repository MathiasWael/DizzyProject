using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OxyPlot;
using DizzyProject.BusinessLogic;
using DizzyProxy.Models;
using OxyPlot.Axes;
using OxyPlot.Series;
using DizzyProxy.Exceptions;

namespace DizzyProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DizzinessGraphPage : ContentPage
	{
		public DizzinessGraphPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            try
            {
                DizzinessController dizzinessController = new DizzinessController();
                List<Dizziness> dizzinesses = await dizzinessController.GetAllDizzinessesWithLevelAsync();

                PlotModel plotModel = new PlotModel();
                plotModel.Axes.Add(new LinearAxis { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Maximum = 10, Minimum = 0, IsPanEnabled = false });
                DateTime dateTime = DateTime.Today;
                plotModel.Axes.Add(new DateTimeAxis { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Position = AxisPosition.Bottom, Minimum = DateTimeAxis.ToDouble(dateTime.AddDays(-14)), Maximum = DateTimeAxis.ToDouble(dateTime) });

                LineSeries lineSeries = new LineSeries();
                lineSeries.Points.AddRange(dizzinessController.GetDizzinessDataPoints(dizzinesses));
                plotModel.Series.Add(lineSeries);

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
    }
}