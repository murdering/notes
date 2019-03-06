using System;

namespace DirectX.DesignPatterns.Factory.MultipleFuncFactory
{
    public class MailSenderMulti : SenderMulti
    {
        public void Send()
        {
            Console.WriteLine("this is mail sender sending!");
        }
    }
}
