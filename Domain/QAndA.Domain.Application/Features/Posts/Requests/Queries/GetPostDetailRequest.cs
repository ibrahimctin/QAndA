using MediatR;
using QAndA.Domain.Application.DTOs.Posts.ResponseDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Posts.Requests.Queries
{
    public class GetPostDetailRequest:IRequest<Result<PostDetailResponse>>
    {
        public string postId { get; set; }
    }
}
