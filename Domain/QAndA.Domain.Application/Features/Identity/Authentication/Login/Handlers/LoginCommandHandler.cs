using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QAndA.Domain.Application.Contracts.Identity;
using QAndA.Domain.Application.DTOs.Authentications.ResponseDtos;
using QAndA.Domain.Application.Features.Identity.Authentication.Login.Requests;
using QAndA.Domain.Entities.IdentityEntities;
using System.IdentityModel.Tokens.Jwt;

namespace QAndA.Domain.Application.Features.Identity.Authentication.Login.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IGenerateJwtToken _jwtToken;
        private readonly IMapper _mapper;

        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IGenerateJwtToken jwtToken, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtToken = jwtToken;
            _mapper = mapper;
        }

        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            var jwtSecurityToken = await _jwtToken.GenerateToken(user);

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;


        }
    }
}
