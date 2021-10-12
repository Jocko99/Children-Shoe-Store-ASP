using Application.Commands.Sizes;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Sizes
{
    public class EfUpdateSizeCommand : IUpdateSizeCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateSizeValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateSizeCommand(ShoeStoreContext context, UpdateSizeValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 24;

        public string Name => "Update Size using Ef";

        public void Execute(SizeDto request)
        {
            var size = _context.Sizes.Find(request.Id);
            if (size == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Size));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, size);
            _context.SaveChanges();
        }
    }
}
