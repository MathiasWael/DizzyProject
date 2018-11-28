using DizzyProxy;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class PatientController
    {   

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            List<Patient> temp = new List<Patient>();
            try
            {
                temp.AddRange(await new PatientResource().GetAllPatientsAsync());
            }

            catch (Exception e)
            {
                Exception t = e;
            }

            return temp;
        }

        public async Task<Patient> CreatePatientAsync(string firstName, string lastName, string email, string password)
        {
            return await new PatientResource().CreatePatientAsync(firstName, lastName, email, password);
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient, string password)
        {

           return await new PatientResource().UpdatePatientAsync(patient, password);
        }

        public async Task<Patient> GetPatientAsync(long id)
        {
            return await new PatientResource().GetPatientAsync(id);
        }
    }
}
