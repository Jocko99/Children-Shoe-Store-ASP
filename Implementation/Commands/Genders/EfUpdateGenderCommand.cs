using Application.Commands.Genders;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Genders
{
    public class EfUpdateGenderCommand : IUpdateGenderCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateGenderValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateGenderCommand(ShoeStoreContext context, UpdateGenderValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Update Gender using Ef";

        public void Execute(GenderDto request)
        {
            var gender = _context.Genders.Find(request.Id);
            if (gender == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Gender));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, gender);
            _context.SaveChanges();
        }
    }
}
