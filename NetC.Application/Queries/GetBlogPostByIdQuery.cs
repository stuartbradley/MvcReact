using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetC.Application.Queries
{
    public class GetBlogPostByIdQuery:IRequest<GetBlogPostByIdQueryDto>
    {
        public int Id { get; }

        public GetBlogPostByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetBlogPostByIdQueryHandler : IRequestHandler<GetBlogPostByIdQuery, GetBlogPostByIdQueryDto>
    {
        private readonly IReadBlogPostService _blogService;

        public GetBlogPostByIdQueryHandler(IReadBlogPostService blogService)
        {
            _blogService = blogService;
        }

        public Task<GetBlogPostByIdQueryDto> Handle(GetBlogPostByIdQuery request, CancellationToken cancellationToken)
        {
            var blogPost = _blogService.GetBlogPostByIdWithComments(request.Id);
            return Task.FromResult(new GetBlogPostByIdQueryDto()
            {
                Id = blogPost.Id,
                Date = blogPost.Date,
                HtmlContent = blogPost.HtmlContent,
                Image = blogPost.Image,
                Title = blogPost.Title,
                Comments = blogPost.Comments?.Select(x => new CommentDto()
                {
                    Id = x.Id,
                    CreationDate = x.Date,
                    EmailAddress = x.EmailAddress,
                    Message = x.Message,
                    Name = x.Name,
                    FileName = x.FileName,
                    Replies = x.Replies?.Select(y => new ReplyDto()
                    {
                        Name = y.Name,
                        CreationDate = y.CreationDate,
                        EmailAddress = y.EmailAddress,
                        Message = y.Message
                    }).ToList()
                }).ToList()
            });
        }

        }
    }

    public class GetBlogPostByIdQueryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string HtmlContent { get; set; }
        public List<CommentDto> Comments { get; set; }
    }

    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
        public List<ReplyDto> Replies { get; set; }
    }

public class ReplyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public string EmailAddress { get; set; }
    public string Message { get; set; }
}
