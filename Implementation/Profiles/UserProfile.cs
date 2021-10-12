using Application.DataTransfer;
using Application.DataTransfer.UsersDto;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(user => user.UserGroups, opt => opt.MapFrom(x => new List<UserGroup> { new UserGroup
                {
                    UserId = x.Id,
                    GroupId = 1
                }}))
                .ForMember(user => user.IsActive, opt => opt.MapFrom(s => true));
            CreateMap<User, UserDto>();
            CreateMap<User, UserSearchDto>()
                .ForMember(dto => dto.Groups, opt => opt.MapFrom(x => x.UserGroups.Select(x => new GroupDto
                {
                    Id = x.Group.Id,
                    Name = x.Group.Name
                }).ToList()))
                ;

            CreateMap<UserInfoDto, User>();

            CreateMap<UserGroupDto, UserGroup>();

        }
    }
}
