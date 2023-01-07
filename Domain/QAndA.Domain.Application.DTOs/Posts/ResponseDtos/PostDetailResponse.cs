using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Common;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;
using System.Text.Json.Serialization;

namespace QAndA.Domain.Application.DTOs.Posts.ResponseDtos
{
    public class PostDetailResponse:BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public IEnumerable<AnswerDetailResponse> Answers { get; set; }
      
        public IEnumerable<QuestionDetailResponse> Questions { get; set; }
    }
}
