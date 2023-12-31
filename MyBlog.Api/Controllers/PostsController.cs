﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.UseCases.Post.Commands;
using MyBlog.Application.UseCases.Post.Queries;

namespace MyBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var request = await mediator.Send(new GetPostsQuery());

            return Ok(request);
        }
    }
}
