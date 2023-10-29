using MediatR;
using MyBlog.Application.Abstractions;
using MyBlog.Application.Notifications;
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
        private readonly IMediator mediator;

        public CreatePostCommandHandler(IApplicationDbContext context,
            IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }
        protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Post()
            {
                Title = request.Title,
                Content = request.Content
            };

            var entry = await context.Posts.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await mediator.Publish(new PostCreatedNotification()
            {
                Id = entry.Entity.Id
            }, cancellationToken);
        }
    }
}
