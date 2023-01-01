using QAndA.Domain.Entities.IdentityEntities;
using System.IdentityModel.Tokens.Jwt;

namespace QAndA.Domain.Application.Contracts.Identity
{
    public interface IGenerateJwtToken
    {
        Task<JwtSecurityToken> GenerateToken(AppUser user);
    }
}
