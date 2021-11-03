using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetC.Application.Commands
{
    public class AddCommentToBlogPostCommand:IRequest<int>
    {
        public int BlogPostId { get; }
        public string Name { get; }
        public DateTime CreationDate { get; }
        public string EmailAddress { get; }
        public string Message { get; }

        public AddCommentToBlogPostCommand(int blogPostId, string name, DateTime creationDate, string emailAddress, string message)
        {
            BlogPostId = blogPostId;
            Name = name;
            CreationDate = creationDate;
            EmailAddress = emailAddress;
            Message = message;
        }
    }

    public class AddCommentToBlogPostCommandHandler : IRequestHandler<AddCommentToBlogPostCommand, int>
    {
        private readonly IWriteBlogPostService _writeBlogService;
        private readonly IReadBlogPostService _readBlogPostService;

        public AddCommentToBlogPostCommandHandler(IWriteBlogPostService writeBlogService, IReadBlogPostService readBlogPostService)
        {
            _writeBlogService = writeBlogService;
            _readBlogPostService = readBlogPostService;
        }
        
        public Task<int> Handle(AddCommentToBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = _readBlogPostService.GetBlogPostByIdWithComments(request.BlogPostId);
            var commentId = blogPost.AddComment(request.Name, request.EmailAddress, request.Message, request.CreationDate);
            _writeBlogService.SaveBlogPost(blogPost);
            return Task.FromResult(commentId);
        }
    }
}
