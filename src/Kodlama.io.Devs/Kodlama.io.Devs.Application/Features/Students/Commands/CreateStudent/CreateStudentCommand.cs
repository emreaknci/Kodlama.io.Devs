using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.Students.Dtos;
using Kodlama.io.Devs.Application.Features.Students.Rules;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand:IRequest<CreatedStudentDto>
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
        public class CreateStudentCommandHandler:IRequestHandler<CreateStudentCommand,CreatedStudentDto>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;
            private readonly StudentBusinessRules _studentBusinessRules;

            public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, StudentBusinessRules studentBusinessRules)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
                _studentBusinessRules = studentBusinessRules;
            }

            public async Task<CreatedStudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                await _studentBusinessRules.GithubAddressCanNotBeDuplicatedWhenInserted(request.GithubAddress);

                var mappedStudent = _mapper.Map<Student>(request);
                var createdStudent = await _studentRepository.AddAsync(mappedStudent);
                var createdStudentDto = _mapper.Map<CreatedStudentDto>(createdStudent);
                return createdStudentDto;
            }
        }
    }
}
