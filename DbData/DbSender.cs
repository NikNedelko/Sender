using api.Models;

namespace api.DbData
{
    public class DbSender
    {
        public string InsertString(Mail mail)
        {
            return "INSERT INTO Mail (Time,Subject,Body,Recipients,Result,FailedMessage) VALUES ('"
            + mail.Time
            + "','"
            + mail.Subject
            + "','"
            + mail.Body
            + "','"
            + mail.Recipients
            + "','"
            + mail.Result
            + "','"
            + mail.FailedMessage
            + "')";
        }
    }
}