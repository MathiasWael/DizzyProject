﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProxy
{
    public class PatientResource : Resource
    {
        public Patient GetPatient(long id) 
            => GetPatientAsync(id).Result;

        public async Task<Patient> GetPatientAsync(long id)
        {
            Request request = new Request(Method.GET, $"patients/{id}");
            return await ExecuteAsync<Patient>(request);
        }

        public Patient CreatePatient(string firstName, string lastName, string email, string password) 
            => CreatePatientAsync(firstName, lastName, email, password).Result;

        public async Task<Patient> CreatePatientAsync(string firstName, string lastName, string email, string password)
        {
            Request request = new Request(Method.POST, "patients");
            request.Body["first_name"] = firstName;
            request.Body["last_name"] = lastName;
            request.Body["email"] = email;
            request.Body["password"] = password;
            JsonWebToken token = await ExecuteAsync<JsonWebToken>(request);
            Token = token.Token;
            return await GetPatientAsync(token.Subject);
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            Request request = new Request(Method.GET, "patients");
            return await ExecuteAsync<List<Patient>>(request);
        }
    }
}