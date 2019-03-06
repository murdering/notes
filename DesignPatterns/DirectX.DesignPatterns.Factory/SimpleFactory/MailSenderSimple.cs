using System;

namespace DirectX.DesignPatterns.Factory.SimpleFactory
{
    public class MailSenderSimple : SenderSimple
    {
        public void Send()
        {
            Console.WriteLine("this is mail sender sending!");
        }
    }
}
