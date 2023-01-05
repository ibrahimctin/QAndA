using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QAndA.Domain.Application.Features.Identity.Authentication.Register.Requests;
using QAndA.Domain.Entities.IdentityEntities;
using System.Security.AccessControl;

namespace QAndA.Domain.Application.Features.Identity.Authentication.Register.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IdentityResult>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public RegisterCommandHandler(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request.RegisterRequest);

            if (user is null)
            {
                return IdentityResult.Failed(new IdentityError() { Description = "REGISTRATION ERROR" });
            }
            var userCreation = await _userManager.CreateAsync(user,request.RegisterRequest.Password);

            if (!userCreation.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError() { Description = "REGISTRATION ERROR" });
            }
            await _userManager.AddToRoleAsync(user, request.RegisterRequest.Roles);

            return IdentityResult.Success;
        }
    }
}
