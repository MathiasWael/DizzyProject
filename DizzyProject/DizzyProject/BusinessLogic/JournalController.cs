using DizzyProject.ViewModels;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class JournalController
    {
        public async Task<List<JournalViewModel>> getAllJournalItemsAsync(DateTime dateTime)
        {
            List<Dizziness> dizzinesses = await new DizzinessController().getAllDizzinessesByDateAsync(dateTime.Date.ToString());
            return null;
        }
    }
}
