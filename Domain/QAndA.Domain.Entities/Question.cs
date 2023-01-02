using QAndA.Domain.Entities.Common;
using QAndA.Domain.Entities.IdentityEntities;

namespace QAndA.Domain.Entities
{
    public class Question:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public IEnumerable<AppUser> Users { get; set; }
       
    }
}
