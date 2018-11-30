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
            List<JournalLogViewModel> temp = journalLogs.FindAll(x => x.Date >= dateTime);
            temp.Sort((x, y) => y.Date.CompareTo(x.Date));
            return temp;
        }

        public List<JournalLogViewModel> getThisMonthJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today;
            DateTime dateTimeWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            List<JournalLogViewModel> temp = journalLogs.FindAll(x => x.Date.Month == dateTime.Month && x.Date <= dateTimeWeek);
            temp.Sort((x, y) => y.Date.CompareTo(x.Date));
            return temp;
        }

        public List<JournalLogViewModel> getLaterJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today;
            List<JournalLogViewModel> temp = journalLogs.FindAll(x => x.Date.Month < dateTime.Month);
            temp.Sort((x, y) => y.Date.CompareTo(x.Date));
            return temp;
        }
    }
}
