using QAndA.Domain.Entities.IdentityEntities;

namespace QAndA.Infrastructure.Extensions
{
    public interface ICurrentUserService
    {
        Task<AppUser> GetCurrentUser();

        Task<string> GetCurrentUserIdAsync();

        Task<string> GetCurrentUserNameAsync();
    }
}
