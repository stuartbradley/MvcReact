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
        public DateTime Date { get; }
        public string EmailAddress { get; }
        public string Message { get; }
        public string FileName { get; }

        private List<Reply> _replies { get; } = new List<Reply>();
        public IReadOnlyList<Reply> Replies => _replies?.AsReadOnly();

        [JsonConstructor]
        public Comment(int id, string name, string emailAddress, string message, DateTime date, string fileName, List<Reply> replies)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            Message = message;
            FileName = fileName;
            Date = date;

            _replies = replies;
            if (_replies == null)
                _replies = new List<Reply>();
        }

        internal void AddReply(string name, string emailAddress, string message, DateTime dateTime)
        {
            _replies.Add(new Reply(name, dateTime, emailAddress, message));
        }
    }
}
