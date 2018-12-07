using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProxy.Models;

namespace DizzyProxy.Resources
{
    public class PatientResource : Resource
    {
        public List<Patient> GetAllPatients()
            => GetAllPatientsAsync().Result;

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            Request request = new Request(Method.GET, "patients");
            return await ExecuteAsync<List<Patient>>(request);
        }

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
            Token = await ExecuteAsync<JsonWebToken>(request);
            return await GetPatientAsync(Token.Subject);
        }

        public Patient UpdatePatient(Patient patient, string currentPassword, string newPassword) 
            => UpdatePatientAsync(patient, currentPassword, newPassword).Result;

        public async Task<Patient> UpdatePatientAsync(Patient patient, string currentPassword, string newPassword)
        {
            Request request = new Request(Method.PUT, "patients/" + patient.Id);
            request.Body["current_password"] = currentPassword;
            request.Body["password"] = newPassword;
            request.Body["phone"] = patient.Phone;
            request.Body["birth_date"] = patient.BirthDate?.ToString("yyyy-MM-dd");
            request.Body["sex"] = patient.Sex?.ToString().ToLower();
            request.Body["height"] = patient.Height;
            request.Body["weight"] = patient.Weight;
            request.Body["zip_code"] = patient.ZipCode;
            request.Body["country_code"] = patient.CountryCode;
            request.Body["address"] = patient.Address;
            return await ExecuteAsync<Patient>(request);
        }
    }
}