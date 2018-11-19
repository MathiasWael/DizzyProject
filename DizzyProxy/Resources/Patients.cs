using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace DizzyProxy
{
    public class Patients
    {
        public async Task<Patient> CreatePatientAsync(string firstName, string lastName, string email, string password)
        {
            IRestClient client = new RestClient();

        }
    }
}
