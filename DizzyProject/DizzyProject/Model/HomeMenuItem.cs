using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.Model
{
    public enum ItemType
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
        public ItemType Type { get; set; }
        public string Title { get; set; }
    }
}
