using MediatR;
using QAndA.Domain.Application.DTOs.Questions.RequestDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Questions.Requests.Commands
{
    public class UpdateQuestionCommand:IRequest<Result>
    {
        public UpdateQuestionRequest UpdateQuestionRequest { get; set; }
        
        public string Id { get; set; }
      
    }
}
