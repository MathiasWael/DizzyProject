using DizzyProxy;
using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.BusinessLogic
{
    public class PatientController
    {

        public List<Patient> GetAllPatientsByPhysiotherapeut(long userId)
        {
            List<Patient> temp = new List<Patient>();
            try
            {
                temp.AddRange(new PatientResource().GetAllPatients(userId));
            }

            catch (Exception e)
            {
                Exception t = e;
            }

            return temp;
        }
    }
}
