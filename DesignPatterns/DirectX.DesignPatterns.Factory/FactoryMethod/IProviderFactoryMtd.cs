using System;
using System.Collections.Generic;
using System.Text;

namespace DirectX.DesignPatterns.Factory.FactoryMethod
{
    public interface IProviderFactoryMtd
    {
        ISenderFactoryMtd Produce();
    }
}
