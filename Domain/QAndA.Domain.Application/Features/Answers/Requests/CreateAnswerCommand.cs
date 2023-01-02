using MediatR;
using QAndA.Domain.Application.DTOs.Answers.RequestDtos;

namespace QAndA.Domain.Application.Features.Answers.Requests
{
    public class CreateAnswerCommand:IRequest<bool>
    {
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public CreateAnswerRequest CreateAnswerRequest { get; set; }
    }
}
