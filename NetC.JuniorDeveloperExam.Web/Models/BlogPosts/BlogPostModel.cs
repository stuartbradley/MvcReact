using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.JuniorDeveloperExam.Web.Models.BlogPost
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string HtmlContext { get; set; }
        public List<CommentModel> Comments { get; set; }
    }

    public class CommentModel
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
    }
}
