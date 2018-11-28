﻿using DizzyProxy.Models;
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
    }
}
