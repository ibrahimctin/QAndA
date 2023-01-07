using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;
using System.Text.Json.Serialization;

namespace QAndA.Domain.Application.DTOs.Posts.RequestDtos
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string QuestionId { get; set; }
        [JsonIgnore]
        public IEnumerable<AnswerDetailResponse>? Answers { get; set; }
        [JsonIgnore]
        public IEnumerable<QuestionDetailResponse>? Questions { get; set; }
    }
}
