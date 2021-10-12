using Application.Commands.Brands;
using Application.DataTransfer;
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
    public class EfCreateBrandCommand : ICreateBrandCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly CreateBrandValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateBrandCommand(ShoeStoreContext context, CreateBrandValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Create new brand using Ef";

        public void Execute(BrandDto request)
        {
            _validator.ValidateAndThrow(request);
            var brand = _mapper.Map<Brand>(request);
            _context.Add(brand);
            _context.SaveChanges();
        }
    }
}
