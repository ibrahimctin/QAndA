using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Common;
using System.Text.Json.Serialization;

namespace QAndA.Domain.Application.DTOs.Questions.ResponseDtos
{
    public  class QuestionDetailResponse:BaseDto
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IEnumerable<AnswerDetailResponse> Answers { get; set; }
       

        public AppUserDetailResponse User { get; set; }
    }
}
