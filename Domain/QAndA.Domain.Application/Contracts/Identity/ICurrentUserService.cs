using QAndA.Domain.Entities.IdentityEntities;

namespace QAndA.Domain.Application.Contracts.Identity
{
    public interface ICurrentUserService
    {
        Task<AppUser> GetCurrentUser();

        Task<string> GetCurrentUserIdAsync();
    }
}
