namespace QAndA.Domain.Entities.Common
{
    public abstract class BaseDomainEntity
    {
        
        public string Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
