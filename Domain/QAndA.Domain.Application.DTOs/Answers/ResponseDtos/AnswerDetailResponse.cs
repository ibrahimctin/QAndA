using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;

namespace QAndA.Domain.Application.DTOs.Answers.ResponseDtos
{
    public class AnswerDetailResponse
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public QuestionDetailResponse Question { get; set; }
        public AppUserDetailResponse User { get; set; }
    }
}
