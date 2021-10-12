using Application.Commands.Genders;
using Application.DataTransfer;
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
    public class EfCreateGenderCommand : ICreateGenderCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateGenderValidator validator;
        private readonly IMapper mapper;

        public EfCreateGenderCommand(ShoeStoreContext context, CreateGenderValidator validator, IMapper mapper)
        {
            _context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Create new Gender using Ef";

        public void Execute(GenderDto request)
        {
            validator.ValidateAndThrow(request);
            var gender = mapper.Map<Gender>(request);
            _context.Add(gender);
            _context.SaveChanges();
        }
    }
}
