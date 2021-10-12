using Application.Commands.Users;
using Application.DataTransfer.UsersDto;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.UserGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfCreateUserGroupCommand : ICreateUserGroupCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UserGroupValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateUserGroupCommand(ShoeStoreContext context, UserGroupValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 28;

        public string Name => "Add User to Group command using Ef";

        public void Execute(UserGroupDto request)
        {
            _validator.ValidateAndThrow(request);
            var userGroup = _mapper.Map<UserGroup>(request);
            _context.Add(userGroup);
            _context.SaveChanges();
        }
    }
}
