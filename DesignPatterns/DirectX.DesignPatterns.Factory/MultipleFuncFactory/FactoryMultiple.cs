using System;
using System.Collections.Generic;
using System.Text;

namespace DirectX.DesignPatterns.Factory.MultipleFuncFactory
{
    public class FactoryMultiple
    {
        public SenderMulti GetMailSender() => new MailSenderMulti();

        public SenderMulti GetSmsSender() => new SmsSenderMulti();

        public static SenderMulti GetStaticMailSender() => new MailSenderMulti();

        public static SenderMulti GetStaticSmsSender() => new SmsSenderMulti();
    }
}
