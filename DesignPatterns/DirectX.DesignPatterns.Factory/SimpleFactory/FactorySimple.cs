namespace DirectX.DesignPatterns.Factory.SimpleFactory
{
    public class FactorySimple
    {
        public SenderSimple GetSender(string senderType)
        {
            switch (senderType)
            {
                case "mail":
                    return new MailSenderSimple();
                case "sms":
                    return new SmsSenderSimple();
                default:
                    return null;
            }
        }
    }
}
