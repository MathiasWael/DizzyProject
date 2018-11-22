using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.ViewModels
{
    public enum HomeMenuItemType
    {
        DizzyRegister,
        StepCounter,
        Exercises,
        Journal,
        Logout,
        Statistics
    }
    public class HomeMenuItem
    {
        public HomeMenuItemType Type { get; set; }
        public string Title { get; set; }
    }
}
