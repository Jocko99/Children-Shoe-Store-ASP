using Application.Commands.Brands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Brands
{
    public class EfUpdateBrandCommand : IUpdateBrandCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly UpdateBrandValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateBrandCommand(ShoeStoreContext context, UpdateBrandValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Update brand using Ef";

        public void Execute(BrandDto request)
        {
            var brand = _context.Brands.Find(request.Id);
            if(brand == null)
            {
                throw new EntityNotFoundException(request.Id,typeof(Brand));
            }
            _validator.ValidateAndThrow(request);
            _mapper.Map(request, brand);
            _context.SaveChanges();
        }
    }
}
