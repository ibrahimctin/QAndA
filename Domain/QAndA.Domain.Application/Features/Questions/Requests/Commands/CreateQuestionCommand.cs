using MediatR;
using QAndA.Domain.Application.DTOs.Questions.RequestDtos;

namespace QAndA.Domain.Application.Features.Questions.Requests.Commands
{
    public class CreateQuestionCommand:IRequest<bool>
    {
        public string UserId { get; set; }
        public CreateQuestionRequest CreateQuestionRequest { get; set; }
    }
}
