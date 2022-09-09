using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using System.Xml.Linq;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Students.Rules
{
    public class StudentBusinessRules
    {
        private readonly IStudentRepository _studentRepository;

        public StudentBusinessRules(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task GithubAddressCanNotBeDuplicatedWhenInserted(string githubAdress)
        {
            var result = await _studentRepository.GetAsync(c => c.GithubAddress == githubAdress);
            if (result != null) throw new BusinessException("This Github Address already registered.");
        }
        public void StudentShouldExistWhenRequested(Student student)
        {
            if (student == null) throw new BusinessException("Requested student does not exist");
        }
    }
}
