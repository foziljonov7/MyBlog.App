using MediatR;
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
        public string Title { get; set; }
        public string Content { get; set; }

        protected override Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
