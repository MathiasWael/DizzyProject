using DizzyProxy.Models;
using DizzyProxy.Resources;
using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class StepCountController
    {
        public async Task<List<StepCount>> GetAllStepCountsAsync()
        {
            return await new StepCountResource().GetAllStepCountsAsync();
        }

        public List<DataPoint> GetStepCountDataPoints(List<StepCount> stepCounts)
        {
            return stepCounts.ConvertAll(new Converter<StepCount, DataPoint>(DataPointStepCountConverter));
        }

        private DataPoint DataPointStepCountConverter(StepCount stepCount)
        {
            return new DataPoint(DateTimeAxis.ToDouble(stepCount.Date), stepCount.Count);
        }
    }
}
