using QAndA.Domain.Entities.Common;

namespace QAndA.Domain.Entities
{
    public class Question:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
