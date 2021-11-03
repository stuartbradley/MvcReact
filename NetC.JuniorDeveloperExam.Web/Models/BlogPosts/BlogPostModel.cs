using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.JuniorDeveloperExam.Web.Models.BlogPosts
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string HtmlContext { get; set; }
        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();
    }

    public class CommentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarLink => "https://eu.ui-avatars.com/api/?name="+FirstName+"+"+LastName;
        public DateTime CreationDate { get; set; }
        private string FirstName => Name.Split()[0];
        private string LastName => Name.Split().Length > 1 ? Name.Split()[1] : ""; 
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public List<ReplyModel> Replies { get; set; } = new List<ReplyModel>();
    }

    public class ReplyModel
    {
        public string Name { get; set; }
        public string AvatarLink => "https://eu.ui-avatars.com/api/?name=" + FirstName + "+" + LastName;
        public DateTime CreationDate { get; set; }
        private string FirstName => Name.Split()[0];
        private string LastName => Name.Split().Length > 1 ? Name.Split()[1] : "";
        public string EmailAddress { get; set; }
        public string Message { get; set; }
    }
}
