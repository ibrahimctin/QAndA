using MediatR;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionDetailByIdQueryRequest:IRequest<Result<QuestionDetailResponse>>
    {
        public string Id { get; set; }
    }
}
