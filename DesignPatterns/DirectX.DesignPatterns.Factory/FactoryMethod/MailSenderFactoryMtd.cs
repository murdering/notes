using System;

namespace DirectX.DesignPatterns.Factory.FactoryMethod
{
    public class MailSenderFactoryMtd : ISenderFactoryMtd
    {
        public void Send()
        {
            Console.WriteLine("this is mail sender sending!");
        }
    }
}
