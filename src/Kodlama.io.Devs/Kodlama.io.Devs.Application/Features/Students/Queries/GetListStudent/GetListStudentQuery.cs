using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kodlama.io.Devs.Application.Features.Students.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Kodlama.io.Devs.Application.Features.Technologies.Models;

namespace Kodlama.io.Devs.Application.Features.Students.Queries.GetListStudent
{
    public class GetListStudentQuery : IRequest<StudentListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListStudentQueryHandler : IRequestHandler<GetListStudentQuery, StudentListModel>
        {
            private readonly IMapper _mapper;
            private readonly IStudentRepository _studentRepository;

            public GetListStudentQueryHandler(IMapper mapper, IStudentRepository studentRepository)
            {
                _mapper = mapper;
                _studentRepository = studentRepository;
            }

            public async Task<StudentListModel> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
            {
                var students = await _studentRepository.GetListAsync(
                    include: m => m.Include(a => a.User), index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedStudents = _mapper.Map<StudentListModel>(students);
                return mappedStudents;
            }
        }

    }
}
