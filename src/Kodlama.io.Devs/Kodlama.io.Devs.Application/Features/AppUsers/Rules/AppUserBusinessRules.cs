using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Dtos;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Rules
{
    public class AppUserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AppUserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserMailCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(b => b.Email == email);
            if (result.Items.Any()) throw new BusinessException($"'{email}' already exists in our system.");
        }

        public async Task UserToCheck(string email)
        {
            var userToCheck = await _userRepository.GetAsync(b => b.Email == email);
            if (userToCheck==null) throw new BusinessException("No records found matching this email");

        }

        public async Task PasswordToCheck(string email, string password)
        {
            var user = await _userRepository.GetAsync(b => b.Email == email);
            if (!HashingHelper.VerifyPasswordHash(password, user!.PasswordHash, user!.PasswordSalt))
                throw new BusinessException("Wrong password error! Please try again.");

        }
    }
}
