using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetC.Application.Commands
{
    public class ReplyToCommentCommand:IRequest<Unit>
    {
        public int BlogPostId { get; }
        public int CommentId { get; }
        public string Name { get; }
        public string EmailAddress { get; }
        public string Message { get; }

        public ReplyToCommentCommand(int blogPostId, int commentId, string name, string emailAddress, string message)
        {
            BlogPostId = blogPostId;
            CommentId = commentId;
            Name = name;
            EmailAddress = emailAddress;
            Message = message;
        }
    }

    public class ReplyToCommentCommandHandler : IRequestHandler<ReplyToCommentCommand, Unit>
    {
        private readonly IWriteBlogPostService _writeBlogService;
        private readonly IReadBlogPostService _readBlogPostService;

        public ReplyToCommentCommandHandler(IWriteBlogPostService writeBlogService, IReadBlogPostService readBlogPostService)
        {
            _writeBlogService = writeBlogService;
            _readBlogPostService = readBlogPostService;
        }
        public Task<Unit> Handle(ReplyToCommentCommand request, CancellationToken cancellationToken)
        {
            var blogPost = _readBlogPostService.GetBlogPostByIdWithComments(request.BlogPostId);
            blogPost.AddReplyToComment(request.CommentId, request.Name, request.EmailAddress, request.Message, DateTime.Now);
            _writeBlogService.SaveBlogPost(blogPost);
            return Task.FromResult(Unit.Value);
        }
    }


}

