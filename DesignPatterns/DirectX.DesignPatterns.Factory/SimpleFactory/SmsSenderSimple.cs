using System;

namespace DirectX.DesignPatterns.Factory.SimpleFactory
{
    public class SmsSenderSimple : SenderSimple
    {
        public void Send()
        {
            Console.WriteLine("this is Sms sender sending!");
        }
    }
}
