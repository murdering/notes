using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateLambdaEvent.Event
{
    public class CarInfoEventArgs : EventArgs
    {
        public string Car { get; }

        public CarInfoEventArgs(string car)
        {
            Car = car;
        }
    }
}