using MediatR;
using QAndA.Domain.Application.DTOs.Answers.RequestDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Answers.Requests.Commands
{
    public class UpdateAnswerCommand:IRequest<Result>
    {
        public string Id { get; set; }

        public UpdateAnswerRequest UpdateAnswerRequest { get; set; }


    }
}
