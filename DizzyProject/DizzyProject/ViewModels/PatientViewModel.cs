using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.ViewModels
{
    public class PatientViewModel
    {
        private DateTime? birthDate;
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate
        {
            get
            {
                if(birthDate == null)
                {
                    return DateTime.Now;
                } else
                {
                    return birthDate;
                }
            }

            set { birthDate = value; }
        }
        public Sex? Sex { get; set; }
        public short? Height { get; set; }
        public short? Weight { get; set; }
        public string FullName { get; set; }

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
            FullName = FirstName + " " + LastName;
        }
    }
}
