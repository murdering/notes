using System;
using System.Collections.Generic;
using System.Text;

namespace DirectX.DesignPatterns.Factory.FactoryMethod
{
    public class FactoryMailSenderMtd: IProviderFactoryMtd
    {
        public ISenderFactoryMtd Produce() => new MailSenderFactoryMtd();
    }
}
