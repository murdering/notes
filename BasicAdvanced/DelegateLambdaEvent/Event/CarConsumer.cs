using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateLambdaEvent.Event
{
    public class CarConsumer
    {
        private readonly string _Name;

        public CarConsumer(string name) => _Name = name;

        public void NewCarIsHere(object sender, CarInfoEventArgs e) => Console.WriteLine($"{_Name}: car {e.Car} is comming!");
    }
}