using Microsoft.AspNetCore.Identity;

namespace QAndA.Domain.Entities.IdentityEntities
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
