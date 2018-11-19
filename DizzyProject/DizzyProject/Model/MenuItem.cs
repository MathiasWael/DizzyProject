using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject.Model
{
    public class MenuItem
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
        public ItemType Type;
        public string Title;
    }
}
