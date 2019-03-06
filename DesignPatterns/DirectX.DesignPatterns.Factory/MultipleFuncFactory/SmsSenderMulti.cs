using System;

namespace DirectX.DesignPatterns.Factory.MultipleFuncFactory
{
    public class SmsSenderMulti : SenderMulti
    {
        public void Send()
        {
            Console.WriteLine("this is Sms sender sending!");
        }
    }
}
