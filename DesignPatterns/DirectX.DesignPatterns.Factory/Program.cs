using DirectX.DesignPatterns.Factory.FactoryMethod;
using DirectX.DesignPatterns.Factory.MultipleFuncFactory;
using DirectX.DesignPatterns.Factory.SimpleFactory;
using System;

namespace DirectX.DesignPatterns.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleFactoryFunction();
            //MultipleFunctionFactoryFunction();
            //StaticFunctionFactoryFunction();
            FactoryFunctionFunction();

            Console.ReadLine();
        }

        // simple factory
        public static void SimpleFactoryFunction()
        {
            var simpleFactory = new FactorySimple();
            var smsSender = simpleFactory.GetSender("mail");
            var mailSender = simpleFactory.GetSender("sms");

            smsSender.Send();
            mailSender.Send();
        }

        // multiple function factory
        public static void MultipleFunctionFactoryFunction()
        {
            var mulFactory = new FactoryMultiple();

            var smsSender = mulFactory.GetSmsSender();
            var mailSender = mulFactory.GetMailSender();

            smsSender.Send();
            mailSender.Send();
        }

        // static function factory
        public static void StaticFunctionFactoryFunction()
        {
            var smsSender = FactoryMultiple.GetStaticSmsSender();
            var mailSender = FactoryMultiple.GetStaticMailSender();

            smsSender.Send();
            mailSender.Send();
        }

        // factory function function
        public static void FactoryFunctionFunction()
        {
            var smsFactory = new FactorySmsSenderMtd();
            var mailFactory = new FactoryMailSenderMtd();

            var smsSender = smsFactory.Produce();
            var mailSender = mailFactory.Produce();

            smsSender.Send();
            mailSender.Send();
        }
    }
}
