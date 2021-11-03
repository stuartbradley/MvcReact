using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.Domain
{
    public class Reply
    {
        public string Name { get; }
        public DateTime CreationDate { get; }
        public string EmailAddress { get; }
        public string Message { get; }

        [JsonConstructor]
        public Reply(string name, DateTime creationDate, string emailAddress, string message)
        {
            Name = name;
            CreationDate = creationDate;
            EmailAddress = emailAddress;
            Message = message;
        }
    }
}
