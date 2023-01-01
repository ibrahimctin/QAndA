using QAndA.Domain.Entities.Common;

namespace QAndA.Domain.Entities
{
    public class Answer:BaseDomainEntity
    {
        public string Content { get; set; }
        public Question Question { get; set; }
    }
}
