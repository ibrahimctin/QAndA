using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using System.Text.Json.Serialization;

namespace QAndA.Domain.Application.DTOs.Questions.RequestDtos
{
    public class CreateQuestionRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public IEnumerable<AppUserDetailResponse>? appUsers { get; set; }
      





    }
}
