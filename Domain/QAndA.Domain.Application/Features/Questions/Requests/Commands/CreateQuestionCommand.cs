using MediatR;
using QAndA.Domain.Application.DTOs.Questions.RequestDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Questions.Requests.Commands
{
    public class CreateQuestionCommand:IRequest<Result>
    {
      
        public CreateQuestionRequest CreateQuestionRequest { get; set; }
    }
}
