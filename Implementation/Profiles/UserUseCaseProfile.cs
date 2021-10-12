using Application.DataTransfer;
using Application.DataTransfer.UsersDto;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class UserUseCaseProfile : Profile
    {
        public UserUseCaseProfile()
        {
            CreateMap<UserUseCaseDto, UserUseCase>();
            CreateMap<UserUseCase, UserUseCaseSearchDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(x => x.Group.Name));
        }
    }
}
