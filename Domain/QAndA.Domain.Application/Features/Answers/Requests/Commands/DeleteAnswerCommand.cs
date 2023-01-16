using MediatR;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Answers.Requests.Commands
{
    public class DeleteAnswerCommand:IRequest<Result>
    {
        public string Id { get; set; }
    }
}
