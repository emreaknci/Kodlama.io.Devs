using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.Students.Dtos;
using Kodlama.io.Devs.Application.Features.Students.Rules;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand:IRequest<UpdatedStudentDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
        public class UpdateStudentCommandHandler:IRequestHandler<UpdateStudentCommand,UpdatedStudentDto>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;
            private readonly StudentBusinessRules _studentBusinessRules;

            public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, StudentBusinessRules studentBusinessRules)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
                _studentBusinessRules = studentBusinessRules;
            }

            public async Task<UpdatedStudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {
                await _studentBusinessRules.GithubAddressCanNotBeDuplicatedWhenInserted(request.GithubAddress);

                var student = _mapper.Map<Student>(request);
                var updatedStudent = await _studentRepository.UpdateAsync(student);
                var updatedStudentDto = _mapper.Map<UpdatedStudentDto>(updatedStudent);
                return updatedStudentDto;
            }
        }
    }
}
