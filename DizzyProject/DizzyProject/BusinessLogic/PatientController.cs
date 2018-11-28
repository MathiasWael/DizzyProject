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

        public Patient CreatePatient(string firstName, string lastName, string email, string password)
        {
            return new PatientResource().CreatePatient(firstName, lastName, email, password);
        }

        public async Task<Patient> UpdatePatient(Patient patient, string password)
        {

           return await new PatientResource().UpdatePatientAsync(patient, password);
        }
    }
}
