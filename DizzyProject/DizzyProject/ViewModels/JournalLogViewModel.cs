using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.ViewModels
{
    public class JournalLogViewModel
    {
        public JournalLogViewModel(JournalLog journalLog)
        {
            Date = journalLog.Date;
        }

        public DateTime Date;

        public string DateString { get { return Date.Date.ToString("d"); } }
    }
}
