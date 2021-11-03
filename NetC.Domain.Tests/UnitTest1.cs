using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetC.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreatingABlogPostShouldPopulateAllFields()
        {
            BlogPost blogPost = CreateBlogPost();

            blogPost.Id.ShouldBe(1);
            blogPost.Date.ShouldBe(DateTime.Now, TimeSpan.FromMinutes(1));
            blogPost.Title.ShouldBe("New Blog Post");
            blogPost.Image.ShouldBe("imageSource");
            blogPost.HtmlContent.ShouldBe("content");
            blogPost.Comments.First().Id.ShouldBe(1);
            blogPost.Comments.First().Name.ShouldBe("Stuart");
            blogPost.Comments.First().EmailAddress.ShouldBe("stuart@hotmail.com");
            blogPost.Comments.First().Message.ShouldBe("This is a message");
            blogPost.Comments.First().Date.ShouldBe(DateTime.Now, TimeSpan.FromMinutes(1));
            blogPost.Comments.First().FileName.ShouldBe("imageLink");
        }

        [Fact]
        public void AddingNewCommentShouldAddCommentToSelectedBlogPost()
        {
            BlogPost blogPost = CreateBlogPost();
            blogPost.AddComment("Wanda", "Wanda@hotmail.co.uk", "I am adding a comment", DateTime.Now, "UploadedFile");
            var comment = blogPost.Comments.Single(x => x.Id == 2);

            comment.Id.ShouldBe(2);
            comment.Name.ShouldBe("Wanda");
            comment.EmailAddress.ShouldBe("Wanda@hotmail.co.uk");
            comment.Message.ShouldBe("I am adding a comment");
            comment.Date.ShouldBe(DateTime.Now, TimeSpan.FromMinutes(1));
            comment.FileName.ShouldBe("UploadedFile");
        }

        [Fact]
        public void AddingReplyShouldAddReplyToSelectedCommment()
        {
            BlogPost blogPost = CreateBlogPost();
            blogPost.AddReplyToComment(1,"Wanda", "Wanda@hotmail.co.uk", "I am adding a reply", DateTime.Now);
            var reply = blogPost.Comments.Single(x => x.Id == 1).Replies.First();

            reply.Name.ShouldBe("Wanda");
            reply.EmailAddress.ShouldBe("Wanda@hotmail.co.uk");
            reply.Message.ShouldBe("I am adding a reply");
            reply.CreationDate.ShouldBe(DateTime.Now, TimeSpan.FromMinutes(1));
        }


        private BlogPost CreateBlogPost()
        {
            Comment comment = new Comment(1, "Stuart", "stuart@hotmail.com", "This is a message", DateTime.Now, "imageLink", null);
            List<Comment> comments = new List<Comment>() { comment };
            BlogPost blogPost = new BlogPost(1, DateTime.Now, "New Blog Post", "imageSource", "content", comments);
            return blogPost;
        }

    }
}
