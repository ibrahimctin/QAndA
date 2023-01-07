using MediatR;
using QAndA.Domain.Application.DTOs.Posts.RequestDtos;
using QAndA.Domain.Application.Helpers.Results;

namespace QAndA.Domain.Application.Features.Posts.Requests.Commands
{
    public class CreatePostCommand:IRequest<Result>
    {
        public string? QuestionId { get; set; }
        public string? AnswerId { get; set; }
        public CreatePostRequest CreatePostRequest { get; set; }
    }
}
