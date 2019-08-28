using System;

namespace Okapia.EmailService
{
    public interface IEmailService
    {
        void SendEmail(string title, string messageBody, string destination);
    }
}