using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class DizzinessResource : Resource
    {
        public async Task<bool> CreateDizzinessAsync(long? exercise_id, int? dizziness, string note)
        {
            Request request = new Request(Method.POST, "patients/" + Token.Subject + "/dizzinesses");

            if (exercise_id != null)
                request.Body["exercise_id"] = exercise_id;
            else
                request.Body["exercise_id"] = null;

            if(dizziness != null)
                request.Body["level"] = dizziness;
            else
                request.Body["level"] = null;

            if (note != null)
                request.Body["note"] = note;
            else
                request.Body["note"] = "";

            return await ExecuteAsync(request);
        }

        public bool CreateDizziness(long? exercise_id, int? dizziness, string note)
           => CreateDizzinessAsync(null, dizziness, note).Result;

        public async Task<List<Dizziness>> GetAllDizzinessesAsync(string query)
        {
            Request request = new Request(Method.GET, "patients/" + Token.Subject + "/dizzinesses" + query);
            return await ExecuteAsync<List<Dizziness>>(request);
        }

        public async Task<List<Dizziness>> GetAllDizzinessesByDateAsync(DateTime dateTime)
        {
            string date = dateTime.ToString("yyyy-MM-dd");
            return await GetAllDizzinessesAsync("?date=" + date);
        }

        public async Task<List<Dizziness>> GetAllDizzinessesWithLevelAsync()
        {
            return await GetAllDizzinessesAsync("?levelgiven=true");
        }
    }
}
