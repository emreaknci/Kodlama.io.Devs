using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Students.Commands.CreateStudent;
using Kodlama.io.Devs.Application.Features.Students.Commands.DeleteStudent;
using Kodlama.io.Devs.Application.Features.Students.Commands.UpdateStudent;
using Kodlama.io.Devs.Application.Features.Students.Dtos;
using Kodlama.io.Devs.Application.Features.Students.Models;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Students.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, StudentListDto>()
                .ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email))
                .ForMember(c => c.FullName, opt => opt.MapFrom(c => $"{c.User.FirstName} {c.User.LastName}"))
                .ReverseMap();
            CreateMap<IPaginate<Student>, StudentListModel>().ReverseMap();

            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, CreatedStudentDto>().ReverseMap();

            CreateMap<Student, DeleteStudentDto>().ReverseMap();
            CreateMap<Student, DeleteStudentCommand>().ReverseMap();

            CreateMap<Student, UpdateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdatedStudentDto>().ReverseMap();

        }
    }
}
