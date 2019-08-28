namespace Okapia.SmsService
{
    public interface ISmsService
    {
        string SendSms(string message, string reciever);
    }
}