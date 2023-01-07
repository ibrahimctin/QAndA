using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Common;

namespace QAndA.Domain.Application.DTOs.Questions.ResponseDtos
{
    public  class QuestionDetailResponse:BaseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IEnumerable<AnswerDetailResponse> Answers { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
