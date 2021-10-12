using Application.Commands.Users;
using Application.DataTransfer.UsersDto;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateUserValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateUserCommand(ShoeStoreContext context, UpdateUserValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 26;

        public string Name => "Update user using Ef";

        public void Execute(UserInfoDto request)
        {
            var user = _context.Users.Find(request.Id);
            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }
            _validator.ValidateAndThrow(request);
            _mapper.Map(request, user);
            _context.SaveChanges();
        }
    }
}
