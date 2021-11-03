using MediatR;
using NetC.Application.Commands;
using NetC.Application.Queries;
using NetC.JuniorDeveloperExam.Web.Models.BlogPosts;
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
                HtmlContext = blogPost.HtmlContent,
                Image = blogPost.Image,
                Title = blogPost.Title,
                Comments = blogPost.Comments?.Select(x => new CommentModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = x.CreationDate,
                    EmailAddress = x.EmailAddress,
                    FileName = x.FileName,
                    Message = x.Message,
                    Replies = x.Replies?.Select(y => new ReplyModel()
                    {
                        Name = y.Name,
                        CreationDate = y.CreationDate,
                        EmailAddress = y.EmailAddress,
                        Message = y.Message
                    }).ToList()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(CommentPostModel model)
        {
            string fileName = "";
            if (model.UploadedFile != null)
            {
                var fileLocation = Server.MapPath("../Assets/CommentFiles/" + model.UploadedFile.FileName);
                model.UploadedFile.SaveAs(fileLocation);
                fileName = model.UploadedFile.FileName;
            }

            await _mediatr.Send(new AddCommentToBlogPostCommand(model.BlogPostId, model.Name, model.CreationDate, model.EmailAddress, model.Message, fileName));
            return RedirectToAction("Index", new { id = model.BlogPostId });
        }

        [Route("BlogPosts/ShowReply/{blogId}/{commentId}")]
        public ActionResult ShowReply(int blogId, int commentId)
        {
            return PartialView("ReplyToComment", new CommentReplyPostModel() { BlogPostId = blogId, CommentId = commentId  });
        }
        [HttpPost]
        public async Task<ActionResult> AddReply(CommentReplyPostModel model)
        {
            await _mediatr.Send(new ReplyToCommentCommand(model.BlogPostId, model.CommentId, model.Name, model.EmailAddress, model.Message));
            return RedirectToAction("Index", model.BlogPostId);
        }
    }
}
