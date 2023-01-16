using MediatR;
using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Answers.Requests.Queries
{
    public class GetAnswerDetailByIdQueryRequest:IRequest<Result<AnswerDetailResponse>>
    {
        public string Id { get; set; }
    }
}
