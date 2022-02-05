using System;
namespace api.Models
{
    /// <summary>
    /// Model of message for database
    /// </summary>
    public class Mail
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipients { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
    }
}
