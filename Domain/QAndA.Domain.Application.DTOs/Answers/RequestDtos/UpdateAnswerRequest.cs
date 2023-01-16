using QAndA.Domain.Application.DTOs.Common;

namespace QAndA.Domain.Application.DTOs.Answers.RequestDtos
{
    public class UpdateAnswerRequest:BaseDto
    {
        public string Content { get; set; }

        public string QuestionId { get; set; }
    }
}
