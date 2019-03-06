using System;

namespace DirectX.DesignPatterns.Factory.FactoryMethod
{
    public class SmsSenderFactoryMtd : ISenderFactoryMtd
    {
        public void Send()
        {
            Console.WriteLine("this is Sms sender sending!");
        }
    }
}
