using MediatR;
using Microsoft.AspNetCore.Mvc;
using QAndA.Domain.Application.DTOs.Answers.RequestDtos;
using QAndA.Domain.Application.Features.Answers.Requests.Commands;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("CreateAnswer")]
        public async Task<ActionResult<Result>> Post([FromBody] CreateAnswerRequest request)
        {
            var command = new CreateAnswerCommand { CreateAnswerRequest = request };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }
    }
}
