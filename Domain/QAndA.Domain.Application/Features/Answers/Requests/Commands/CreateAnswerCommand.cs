using MediatR;
using QAndA.Domain.Application.DTOs.Answers.RequestDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Answers.Requests.Commands
{
    public class CreateAnswerCommand:IRequest<Result>
    {
        public CreateAnswerRequest CreateAnswerRequest { get; set; }
        public string QuestionId { get; set; }
    }
}
