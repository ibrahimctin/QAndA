using QAndA.Domain.Entities.Common;

namespace QAndA.Domain.Entities
{
    public class Post:BaseDomainEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
