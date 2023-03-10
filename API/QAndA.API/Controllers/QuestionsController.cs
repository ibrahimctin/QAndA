using MediatR;
using Microsoft.AspNetCore.Mvc;
using QAndA.Domain.Application.DTOs.Questions.RequestDtos;
using QAndA.Domain.Application.Features.Questions.Requests.Commands;
using QAndA.Domain.Application.Features.Questions.Requests.Queries;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("CreateQuestion")]
        public async Task<ActionResult<Result>> Post([FromBody] CreateQuestionRequest request)
        {
            var command = new CreateQuestionCommand { CreateQuestionRequest = request };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }
        [HttpPost("UpdateQuestion")]
        public async Task<ActionResult<Result>> UpdateQuestion([FromBody] UpdateQuestionRequest request ,string id)
        {
            var command = new UpdateQuestionCommand { UpdateQuestionRequest = request,Id=id };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);

        }


        [HttpGet("GetQuestionDetail")]
        public async Task<IActionResult> GetQuestion([FromBody] string id, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new GetQuestionDetailByIdQueryRequest { Id = id }, cancellationToken));


        [HttpDelete("DeleteQuestion")]
        public async Task<IActionResult> DeleteAnswer(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteQuestionCommand { Id = id }, cancellationToken);

            if (result.Success == false)
            {
                return result.ApiResult;
            }

            return NoContent();
        }

    }
}
    