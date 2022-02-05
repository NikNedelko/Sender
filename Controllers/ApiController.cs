using System.Collections.Generic;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/mails")]
    public class ApiController : Controller
    {
        [HttpGet]
        public IEnumerable<Mail> Get()
        {
            MySqlConnection conn = new MySqlConnection(Constants.connStr);
            MySqlDataReader reader = new MySqlCommand(Constants.sql, conn).ExecuteReader();

            conn.Open();

            List<Mail> result = new List<Mail>();

            while (reader.Read())
            {
                result.Add(new Mail
                {
                    Time = reader[0].ToString(),
                    Subject = reader[1].ToString(),
                    Body = reader[2].ToString(),
                    Recipients = reader[3].ToString(),
                    Result = reader[4].ToString(),
                    FailedMessage = reader[5].ToString(),
                });
            }

            conn.Close();

            return result.ToArray();

        }

        [HttpPost]
        public void Post([FromBody] string postValue)
        {
            new SendEmailController().Sender(JsonConvert.DeserializeObject<IncomingMail>(postValue));
        }
    }

}
