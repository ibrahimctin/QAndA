using QAndA.Domain.Entities.Common;
using QAndA.Domain.Entities.IdentityEntities;

namespace QAndA.Domain.Entities
{
    public class Answer:BaseDomainEntity
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public AppUser User { get; set; }
    }
}
