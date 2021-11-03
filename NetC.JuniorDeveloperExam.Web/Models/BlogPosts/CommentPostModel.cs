using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.JuniorDeveloperExam.Web.Models.BlogPosts
{
    public class CommentPostModel
    {
        public string Name { get; set; }
        public DateTime CreationDate => DateTime.Now;
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public int BlogPostId { get; set; }
    }
}
