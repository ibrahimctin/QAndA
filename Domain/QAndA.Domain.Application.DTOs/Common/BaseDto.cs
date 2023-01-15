namespace QAndA.Domain.Application.DTOs.Common
{
    public class BaseDto
    {
        public string Id { get; set; }
       
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
