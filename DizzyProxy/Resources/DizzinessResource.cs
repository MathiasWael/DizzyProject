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
        public async Task<Dizziness> SubmitAsync(int? exercise_id, int dizziness, string note)
        {
            Request request = new Request(Method.POST, "dizzinesses");
            request.Body["patient_id"] = Token.Subject;

            if(exercise_id != null)
            request.Body["exercise_id"] = exercise_id;

            request.Body["level"] = dizziness;
            request.Body["note"] = note;
            return await ExecuteAsync<Dizziness>(request);
        }

        public Dizziness Submit(int? exercise_id, int dizziness, string note)
           => SubmitAsync(null, dizziness, note).Result;

        public async Task<List<Dizziness>> GetAllDizzinessesAsync(string query)
        {
            Request request = new Request(Method.GET, "dizzinesses" + query);
            return await ExecuteAsync<List<Dizziness>>(request);
        }

        public async Task<List<Dizziness>> GetAllDizzinessesByDateAsync(DateTime dateTime)
        {
            string date = dateTime.Year.ToString() + "-" + dateTime.Month + "-" + dateTime.Day;
            return await GetAllDizzinessesAsync("?date=" + date);
        }

        public async Task<List<Dizziness>> GetAllDizzinessesWithLevelAsync()
        {
            return await GetAllDizzinessesAsync("?levelgiven=true");
        }
    }
}
