using System;
using DizzyProxy.Models;

namespace DizzyProject.ViewModels
{
    public class PatientViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Sex? Sex { get; set; }
        public short? Height { get; set; }
        public short? Weight { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get
            {
                return _birthDate == null ? DateTime.Now : _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        public PatientViewModel(Patient patient)
        {
            Id = patient.Id;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Email = patient.Email;
            Phone = patient.Phone;
            BirthDate = patient.BirthDate;
            Sex = patient.Sex;
            Height = patient.Height;
            Weight = patient.Weight;
            ZipCode = patient.ZipCode;
            CountryCode = patient.CountryCode;
            Address = patient.Address;
            FullName = FirstName + " " + LastName;
        }
    }
}