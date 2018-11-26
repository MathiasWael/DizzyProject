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

        public async Task<List<Patient>> GetAllPatients()
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
    }
}
