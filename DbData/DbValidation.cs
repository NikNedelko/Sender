using System;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.DbData
{
    class DbValidation
    {
        public void Validator(IncomingMail mail, string person, bool wasSend)
        {
            MySqlConnection conn = new MySqlConnection(Constants.connStr);

            var result = new Mail()
            {
                Time = DateTime.Now.ToString(),
                Subject = mail.subject,
                Body = mail.body,
                Recipients = person,
                Result = wasSend ? "Ok" : "Failed",
                FailedMessage = wasSend ? "something was wrong :(" : null,
            };

            conn.Open();
            new MySqlCommand(new DbSender().InsertString(result),conn).ExecuteNonQuery();
            conn.Close();
        }

    }
}
