using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using OxyPlot;
using OxyPlot.Axes;

namespace DizzyProject.BusinessLogic
{
    public class StepCountController
    {
        private StepCountResource _stepCountResource;

        public StepCountController()
        {
            _stepCountResource = new StepCountResource();
        }

        public async Task<List<StepCount>> GetAllStepCountsAsync()
        {
            return await _stepCountResource.GetAllStepCountsAsync(Resource.UserId);
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