using Application.Commands.Users;
using Application.DataTransfer.UsersDto;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.UserUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfCreateUserUseCaseCommand : ICreateUserUseCaseCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UserUseCaseValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateUserUseCaseCommand(ShoeStoreContext context, UserUseCaseValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 30;

        public string Name => "Create Use Case using Ef";

        public void Execute(UserUseCaseDto request)
        {
            _validator.ValidateAndThrow(request);
            var usecase = _mapper.Map<UserUseCase>(request);
            _context.Add(usecase);
            _context.SaveChanges();
        }
    }
}
