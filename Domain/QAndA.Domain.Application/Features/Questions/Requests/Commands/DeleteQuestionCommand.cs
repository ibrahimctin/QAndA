using MediatR;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Questions.Requests.Commands
{
    public class DeleteQuestionCommand:IRequest<Result>
    {
        public string Id { get; set; }
    }
}
