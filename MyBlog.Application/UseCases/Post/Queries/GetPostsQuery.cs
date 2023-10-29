using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Abstractions;
using MyBlog.Application.UseCases.Post.Dtos;
using MyBlog.Application.UseCases.Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.UseCases.Post.Queries
{
    public class GetPostsQuery : IRequest<List<PostDto>>
    {
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly IApplicationDbContext context;
        public GetPostsQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await context.Posts.Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            }).ToListAsync(cancellationToken);

            return posts;
        }
    }
}
