using Application.Commands.Users;
using Application.DataTransfer.UsersDto;
using Application.Exceptions;
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
    public class EfUpdateUserUseCaseCommand : IUpdateUserUseCaseCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UserUseCaseValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateUserUseCaseCommand(ShoeStoreContext context, UserUseCaseValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 31;

        public string Name => "Update User Use Case command using Ef";

        public void Execute(UserUseCaseDto request)
        {
            var usecase = _context.UserUseCases.Find(request.Id);
            if (usecase == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(UserUseCase));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, usecase);
            _context.SaveChanges();
        }
    }
}
