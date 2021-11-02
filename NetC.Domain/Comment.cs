using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.Domain
{
    public class Comment
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime CreationDate { get; }
        public string EmailAddress { get; }
        public string Message { get; }

        [JsonConstructor]
        public Comment(int id, string name, string emailAddress, string message, DateTime date)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            Message = message;
            CreationDate = date;
        }
    }
}
