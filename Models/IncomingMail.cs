using System;
using System.Collections.Generic;

namespace api.Models
{
    /// <summary>
    /// Model of default Json from Post request 
    /// </summary>
    public class IncomingMail
    {
        public string subject { get; set; }
        public string body { get; set; }
        public string[] recipients { get; set; }
    }
}
