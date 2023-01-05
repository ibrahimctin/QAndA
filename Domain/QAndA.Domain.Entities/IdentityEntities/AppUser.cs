using Microsoft.AspNetCore.Identity;

namespace QAndA.Domain.Entities.IdentityEntities
{
    public class AppUser:IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
