using System;

namespace DizzyProject.ViewModels
{
    public class JournalLogViewModel
    {
        public DateTime Date;
        public string DateString => Date.ToString("yyyy-MM-dd");
    }
}