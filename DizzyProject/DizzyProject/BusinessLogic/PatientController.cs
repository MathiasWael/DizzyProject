using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class PatientController
    {
        private PatientResource _patientResource;

        public PatientController()
        {
            _patientResource = new PatientResource();
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patientResource.GetAllPatientsAsync();
        }

        public async Task<Patient> CreatePatientAsync(string firstName, string lastName, string email, string password)
        {
            return await _patientResource.CreatePatientAsync(firstName, lastName, email, password);
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient, string currentPassword, string newPassword)
        {
            return await _patientResource.UpdatePatientAsync(patient, currentPassword, newPassword);
        }

        public async Task<Patient> GetPatientAsync(long id)
        {
            return await _patientResource.GetPatientAsync(id);
        }
    }
}