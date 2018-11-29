using DizzyProject.ViewModels;
using DizzyProxy.Models;
using DizzyProxy.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace DizzyProject.BusinessLogic
{
    public class JournalLogController
    {
        public async Task<List<JournalLogViewModel>> getAllJournalLogsAsync()
        {
            List<JournalLog> temp = await new JournalLogResource().GetAllJournalLogsAsync();
            return temp.ConvertAll(new Converter<JournalLog, JournalLogViewModel>(JournalViewConverter));
        }

        private static JournalLogViewModel JournalViewConverter(JournalLog journalLog)
        {
            return new JournalLogViewModel(journalLog);
        }

        public List<JournalLogViewModel> getThisWeekJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            return journalLogs.FindAll(x => x.Date  >= dateTime);
        }

        public List<JournalLogViewModel> getThisMonthJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today;
            DateTime dateTimeWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            return journalLogs.FindAll(x => x.Date.Month == dateTime.Month && x.Date <= dateTimeWeek);
        }

        public List<JournalLogViewModel> getLaterJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today;
            return journalLogs.FindAll(x => x.Date.Month < dateTime.Month);
        }
    }
}
