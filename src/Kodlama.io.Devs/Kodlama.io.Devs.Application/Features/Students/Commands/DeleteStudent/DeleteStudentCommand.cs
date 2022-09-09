using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.Students.Dtos;
using Kodlama.io.Devs.Application.Features.Students.Rules;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand:IRequest<DeleteStudentDto>
    {
        public int Id { get; set; }
        public class DeleteStudentCommandHandler:IRequestHandler<DeleteStudentCommand,DeleteStudentDto>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;
            private readonly StudentBusinessRules _studentBusinessRules;

            public DeleteStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, StudentBusinessRules studentBusinessRules)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
                _studentBusinessRules = studentBusinessRules;
            }

            public async Task<DeleteStudentDto> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetAsync(c => c.Id == request.Id);
                _studentBusinessRules.StudentShouldExistWhenRequested(student);
                await _studentRepository.DeleteAsync(student);
                var deletedStudentDto = _mapper.Map<DeleteStudentDto>(student);
                return deletedStudentDto;

            }
        }
    }
}
