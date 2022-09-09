using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.AppUsers.Commands.CreateAppUser;
using Kodlama.io.Devs.Application.Features.AppUsers.Models;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Profiles
{
    public class MappingProfiles
    {
        public MappingProfiles()
        {
            //CreateMap<UserForRegisterDto, CreateAppUserCommand>().ReverseMap();
            //CreateMap<AccessToken, CreatedAppUserModel>().ReverseMap();
        }
    }
}
