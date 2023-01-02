﻿using MediatR;
using QAndA.Domain.Application.DTOs.Authentications.ResponseDtos;

namespace QAndA.Domain.Application.Features.Identity.Authentication.Login.Requests
{
    public class LoginCommand:IRequest<AuthResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
