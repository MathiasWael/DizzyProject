using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Resources;
using DizzyProxy.Models;
using OxyPlot;
using OxyPlot.Axes;

namespace DizzyProject.BusinessLogic
{
    public class DizzinessController
    {
        DizzinessResource dr = new DizzinessResource();

        public async Task<Dizziness> SubmitAsync(int dizziness, string note)
        {
            return await dr.SubmitAsync(null, dizziness, note);
        }

        public async Task<List<Dizziness>> GetAllDizzinessesByDateAsync(DateTime dateTime)
        {
            return await new DizzinessResource().GetAllDizzinessesByDateAsync(dateTime);
        }

        public async Task<List<Dizziness>> GetAllDizzinessesWithLevelAsync()
        {
            return await new DizzinessResource().GetAllDizzinessesWithLevelAsync();
        }

        public List<DataPoint> GetDizzinessDataPoints(List<Dizziness> dizzinesses)
        {
            List<DataPoint> temp = new List<DataPoint>();
            dizzinesses.Sort((x, y) => y.Created.CompareTo(x.Created));
            while (dizzinesses.Count != 0)
            {
                int count = 0;
                int totalDizziness = 0;

                foreach (Dizziness dizziness in dizzinesses.FindAll(x => x.Created.Date == dizzinesses[0].Created.Date))
                {
                    count++;
                    totalDizziness += (int)dizziness.Level;
                }

                temp.Add(new DataPoint(DateTimeAxis.ToDouble(dizzinesses[0].Created), totalDizziness / count));
                count = 0;
                totalDizziness = 0;
                DateTime dateTime = dizzinesses[0].Created;
                dizzinesses.RemoveAll(x => x.Created.Date == dateTime.Date);
            }
            return temp;
        }
    }
}
