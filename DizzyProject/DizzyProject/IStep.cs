using System;
using System.Collections.Generic;
using System.Text;

namespace DizzyProject
{
    public interface IStep
    {
        event EventHandler CountChanged;
        int? Count { get; }
        void Connect();
    }
}
