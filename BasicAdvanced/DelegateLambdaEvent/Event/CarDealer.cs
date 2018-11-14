using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DelegateLambdaEvent.Event
{
    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            WriteLine($"Car Dealer, new is coming: {car}");

            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
}