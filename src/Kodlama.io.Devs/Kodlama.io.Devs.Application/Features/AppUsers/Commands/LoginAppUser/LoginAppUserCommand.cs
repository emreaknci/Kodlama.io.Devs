using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.AppUsers.Models;
using Kodlama.io.Devs.Application.Features.AppUsers.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.LoginAppUser
{
    public class LoginAppUserCommand:IRequest<LoggedInAppUserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AuthenticatorCode { get; set; }
        public class LoginAppUserCommandHandler:IRequestHandler<LoginAppUserCommand,LoggedInAppUserModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly AppUserBusinessRules _userBusinessRules;

            public LoginAppUserCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, AppUserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<LoggedInAppUserModel> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserToCheck(request.Email);
                await _userBusinessRules.PasswordToCheck(request.Email, request.Password);

                var user = await _userRepository.GetAsync(c => c.Email == request.Email);
                var claims = _userRepository.GetClaims(user);
                var accessToken = _tokenHelper.CreateToken(user, claims);
                return new()
                {
                    Expiration = accessToken.Expiration,
                    Token = accessToken.Token
                };
            }
        }
    }
}
