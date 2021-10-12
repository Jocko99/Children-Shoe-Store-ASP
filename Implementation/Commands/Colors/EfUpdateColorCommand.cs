using Application.Commands.Colors;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Color;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Colors
{
    public class EfUpdateColorCommand : IUpdateColorCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateColorValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateColorCommand(ShoeStoreContext context, UpdateColorValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Update Color using Ef";

        public void Execute(ColorDto request)
        {
            var color = _context.Colors.Find(request.Id);
            if(color == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Color));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, color);
            _context.SaveChanges();
        }
    }
}
