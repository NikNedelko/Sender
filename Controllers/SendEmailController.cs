using System;
using api.Models;
using System.Net.Mail;
using System.Net;
using api.DbData;

namespace api.Controllers
{
    public class SendEmailController
    {
        public void Sender(IncomingMail mail)
        {
            SmtpClient client = new SmtpClient()
            {
                Host = Constants.host,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = Constants.testEmail,
                    Password = Constants.testEmailPassword
                },
            };

            MailAddress fromEmail = new MailAddress(Constants.testEmail, Constants.testMailHeader);

            foreach (var reciever in mail.recipients)
            {
                MailMessage message = new MailMessage()
                {
                    From = fromEmail,
                    Subject = mail.subject,
                    Body = mail.body
                };

                message.To.Add(new MailAddress(reciever, "Magic"));
                bool error = false;

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    error = true;
                    Console.WriteLine(ex);
                }

                new DbValidation().Validator(mail, reciever, error);
            }
        }
    }
}
