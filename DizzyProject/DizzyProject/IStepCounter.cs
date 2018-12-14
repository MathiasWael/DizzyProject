using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject
{
    public interface IStepCounter
    {
        void StartSensor();
        event EventHandler CountChanged;
        int Count { get; }
    }
}
