using Application.Commands.Sizes;
using Application.DataTransfer;
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
    public class EfCreateSizeCommand : ICreateSizeCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateSizeValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateSizeCommand(ShoeStoreContext context, CreateSizeValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 23;

        public string Name => "Create new size using Ef";

        public void Execute(SizeDto request)
        {
            _validator.ValidateAndThrow(request);
            var size = _mapper.Map<Size>(request);
            _context.Add(size);
            _context.SaveChanges();
        }
    }
}
