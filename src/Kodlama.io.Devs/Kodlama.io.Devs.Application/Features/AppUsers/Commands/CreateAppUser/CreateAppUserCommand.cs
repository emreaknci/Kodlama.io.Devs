using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.AppUsers.Models;
using Kodlama.io.Devs.Application.Features.AppUsers.Rules;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Commands.CreateAppUser
{
    public class CreateAppUserCommand : IRequest<CreatedAppUserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreatedAppUserModel>
        {
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserRepository _userRepository;
            private readonly AppUserBusinessRules _appUserBusinessRules;

            public CreateAppUserCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository, AppUserBusinessRules appUserBusinessRules)
            {
                _tokenHelper = tokenHelper;
                _userRepository = userRepository;
                _appUserBusinessRules = appUserBusinessRules;
            }

            public async Task<CreatedAppUserModel> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
            {
                await _appUserBusinessRules.UserMailCanNotBeDuplicatedWhenInserted(request.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                await _userRepository.AddAsync(user);

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
