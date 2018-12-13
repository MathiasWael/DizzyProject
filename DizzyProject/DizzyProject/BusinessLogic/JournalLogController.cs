using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DizzyProject.ViewModels;
using DizzyProxy.Models;
using DizzyProxy.Resources;

namespace DizzyProject.BusinessLogic
{
    public class JournalLogController
    {
        private JournalLogResource _journalLogResource;

        public JournalLogController()
        {
            _journalLogResource = new JournalLogResource();
        }

        public async Task<List<JournalLogViewModel>> GetAllJournalLogsAsync(long? patientId)
        {
            List<JournalLog> logs = await _journalLogResource.GetAllJournalLogsAsync(LogicHelper.GetPatientId(patientId));
            return logs.ConvertAll(new Converter<JournalLog, JournalLogViewModel>(JournalViewConverter));
        }

        private static JournalLogViewModel JournalViewConverter(JournalLog journalLog)
        {
            return new JournalLogViewModel { Date = journalLog.Date.AddDays(1) };
        }

        public List<JournalLogViewModel> GetThisWeekJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            List<JournalLogViewModel> viewModels = journalLogs.FindAll(x => x.Date >= dateTime);
            viewModels.Sort((a, b) => b.Date.CompareTo(a.Date));
            return viewModels;
        }

        public List<JournalLogViewModel> GetThisMonthJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today;
            DateTime dateTimeWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            List<JournalLogViewModel> viewModels = journalLogs.FindAll(x => x.Date.Month == dateTime.Month && x.Date <= dateTimeWeek);
            viewModels.Sort((a, b) => b.Date.CompareTo(a.Date));
            return viewModels;
        }

        public List<JournalLogViewModel> GetLaterJournals(List<JournalLogViewModel> journalLogs)
        {
            DateTime dateTime = DateTime.Today;
            List<JournalLogViewModel> viewModels = journalLogs.FindAll(x => x.Date.Month < dateTime.Month);
            viewModels.Sort((a, b) => b.Date.CompareTo(a.Date));
            return viewModels;
        }
    }
}