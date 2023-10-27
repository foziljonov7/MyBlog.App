using MediatR;
using MyBlog.Application.Abstractions;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.UseCases.Post.Commands
{
    public class CreatePostCommand : IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
    {
        private readonly IApplicationDbContext context;

        public CreatePostCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Post()
            {
                Title = request.Title,
                Content = request.Content
            };

            context.Posts.Add(entity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
