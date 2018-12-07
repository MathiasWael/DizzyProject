using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class DizzinessResource : Resource
    {
        public List<Dizziness> GetAllDizzinesses(long userId) =>
            GetAllDizzinessesAsync(userId).Result;

        public async Task<List<Dizziness>> GetAllDizzinessesAsync(long userId)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/dizzinesses");
            return await ExecuteAsync<List<Dizziness>>(request);
        }

        public List<Dizziness> GetAllDizzinesses(long userId, DateTime? date) =>
            GetAllDizzinessesAsync(userId, date).Result;

        public async Task<List<Dizziness>> GetAllDizzinessesAsync(long userId, DateTime? date)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/dizzinesses");
            request.Query["date"] = date?.ToString("yyyy-MM-dd");
            return await ExecuteAsync<List<Dizziness>>(request);
        }

        public List<Dizziness> GetAllDizzinesses(long userId, DateTime? date, bool? levelGiven) =>
            GetAllDizzinessesAsync(userId, date, levelGiven).Result;

        public async Task<List<Dizziness>> GetAllDizzinessesAsync(long userId, DateTime? date, bool? levelGiven)
        {
            Request request = new Request(Method.GET, $"patients/{userId}/dizzinesses");
            request.Query["date"] = date?.ToString("yyyy-MM-dd");
            request.Query["levelgiven"] = levelGiven == null ? null : ((bool)levelGiven ? "true" : "false");
            return await ExecuteAsync<List<Dizziness>>(request);
        }

        public Dizziness CreateDizziness(long userId, long? exerciseId, int? dizziness, string note) =>
            CreateDizzinessAsync(userId, exerciseId, dizziness, note).Result;

        public async Task<Dizziness> CreateDizzinessAsync(long userId, long? exerciseId, int? dizziness, string note)
        {
            Request request = new Request(Method.POST, $"patients/{userId}/dizzinesses");
            request.Body["exercise_id"] = exerciseId;
            request.Body["level"] = dizziness;
            request.Body["note"] = note;
            return await ExecuteAsync<Dizziness>(request);
        }
    }
}