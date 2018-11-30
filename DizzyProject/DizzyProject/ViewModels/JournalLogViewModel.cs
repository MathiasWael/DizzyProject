using DizzyProxy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.ViewModels
{
    public class JournalLogViewModel
    {
        public DateTime Date;

        public string DateString { get { return Date.Year.ToString() + "-" + Date.Month + "-" + Date.Day; } }
    }
}
