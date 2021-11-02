using MediatR;
using NetC.Application.Queries;
using NetC.JuniorDeveloperExam.Web.Models.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogPostsController:Controller
    {
        private readonly IMediator _mediatr;

        public BlogPostsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        public async Task<ActionResult> Index(int id)
        {
            var blogPost = await _mediatr.Send(new GetBlogPostByIdQuery(id));
            BlogPostModel model = new BlogPostModel()
            {
                Id = blogPost.Id,
                Date = blogPost.Date,
                HtmlContext = blogPost.HtmlContext,
                Image = blogPost.Image,
                Title = blogPost.Title,
                Comments = blogPost.Comments.Select(x => new CommentModel()
                {
                    Name = x.Name,
                    CreationDate = x.CreationDate,
                    EmailAddress = x.EmailAddress,
                    Message = x.Message
                }).ToList()
            };
            return View(model);
        }
    }
}
