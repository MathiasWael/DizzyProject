using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RestSharp;
using DizzyProxy.Resources;

namespace DizzyProxy
{
    public class PatientResource : Resource
    {
        //public Patient GetPatient(long id) => GetPatientAsync(id).Result;
        //public async Task<Patient> GetPatientAsync(long id)
        //{
        //    IRestRequest request = new RestRequest(Method.GET) { Resource = "patients" };
        //    return await ExecuteAsync<Patient>(request);
        //}

        //public Patient CreatePatient(string firstName, string lastName, string email, string password) 
        //    => CreatePatientAsync(firstName, lastName, email, password).Result;

        //public async Task<Patient> CreatePatientAsync(string firstName, string lastName, string email, string password)
        //{
        //    IRestRequest request = new RestRequest(Method.POST) { Resource = "patients" };
        //    request.AddParameter("first_name", firstName, ParameterType.RequestBody);
        //    request.AddParameter("last_name", firstName, ParameterType.RequestBody);
        //    request.AddParameter("email", firstName, ParameterType.RequestBody);
        //    request.AddParameter("password", firstName, ParameterType.RequestBody);
        //    JsonWebToken token = await ExecuteAsync<JsonWebToken>(request);
        //    Token = token.Token;
        //    return await GetPatientAsync(token.UserId);
        //}
    }
}
