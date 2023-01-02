using MediatR;
using Microsoft.AspNetCore.Identity;
using QAndA.Domain.Application.DTOs.Authentications.RequestDtos;

namespace QAndA.Domain.Application.Features.Identity.Authentication.Register.Requests
{
    public class RegisterCommand:IRequest<IdentityResult>
    {
        public RegisterRequest RegisterRequest { get; set; }
    }
}
