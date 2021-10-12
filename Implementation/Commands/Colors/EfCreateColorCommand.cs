using Application.Commands.Colors;
using Application.DataTransfer;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Colors
{
    public class EfCreateColorCommand : ICreateColorCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateColorValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateColorCommand(ShoeStoreContext context, CreateColorValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Create new color using Ef";

        public void Execute(ColorDto request)
        {
            _validator.ValidateAndThrow(request);
            var color = _mapper.Map<Color>(request);
            _context.Add(color);
            _context.SaveChanges();
        }
    }
}
