using System;
using System.Collections.Generic;
using System.Text;

namespace DirectX.DesignPatterns.Factory.FactoryMethod
{
    public class FactorySmsSenderMtd : IProviderFactoryMtd
    {
        public ISenderFactoryMtd Produce() => new SmsSenderFactoryMtd();
    }
}
