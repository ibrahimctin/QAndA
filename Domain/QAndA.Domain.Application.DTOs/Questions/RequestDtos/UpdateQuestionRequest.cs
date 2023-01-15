using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Common;
using System.Text.Json.Serialization;

namespace QAndA.Domain.Application.DTOs.Questions.RequestDtos
{
    public class UpdateQuestionRequest:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public AppUserDetailResponse? User { get; set; }
    }
}
