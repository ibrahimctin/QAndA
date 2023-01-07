using MediatR;
using Microsoft.AspNetCore.Mvc;
using QAndA.Domain.Application.DTOs.Posts.RequestDtos;
using QAndA.Domain.Application.DTOs.Posts.ResponseDtos;
using QAndA.Domain.Application.Features.Posts.Requests.Commands;
using QAndA.Domain.Application.Features.Posts.Requests.Queries;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreatePost")]
        public async Task<ActionResult<Result>> Post([FromBody] CreatePostRequest request)
        {
            var command = new CreatePostCommand { CreatePostRequest = request };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDetailResponse>> Get(string id)
        {
            var post = await _mediator.Send(new GetPostDetailRequest { postId = id });
            return Ok(post);
        }
    }
}
