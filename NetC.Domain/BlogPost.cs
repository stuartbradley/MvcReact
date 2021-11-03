using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.Domain
{
    public class BlogPost
    {
        public int Id { get; }
        public DateTime Date { get; }
        public string Title { get; }
        public string Image { get; }
        public string HtmlContext { get; }
        private List<Comment> _comments = new List<Comment>();
        public IReadOnlyList<Comment> Comments => _comments?.AsReadOnly();

        [JsonConstructor]
        public BlogPost(int id, DateTime date, string title, string image, string htmlContent, List<Comment> comments)
        {
            Id = id;
            Date = date;
            Title = title;
            Image = image;
            HtmlContext = htmlContent;
            _comments = comments;
            if (_comments == null)
                _comments = new List<Comment>();
        }

        public int AddComment(string name, string emailAddress, string comment, DateTime creationDate)
        {

            var id = _comments.Max(x => x.Id) + 1;
            _comments.Add(new Comment(id, name, emailAddress, comment, creationDate, new List<Reply>()));

            return id;
        }

        public void AddReplyToComment(int commentId, string name, string emailAddress, string message, DateTime createdDate)
        {
            _comments.Single(x => x.Id == commentId).AddReply(name, emailAddress, message, createdDate);
        }
    }
}
