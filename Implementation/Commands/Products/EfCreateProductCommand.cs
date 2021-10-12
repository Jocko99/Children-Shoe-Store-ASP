using Application.Commands.Products;
using Application.DataTransfer.ProductsDto;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Products
{
    public class EfCreateProductCommand : ICreateProductCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly ProductValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateProductCommand(ShoeStoreContext context, ProductValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Create new Product using Ef.";

        public void Execute(ProductDto request)
        {
            _validator.ValidateAndThrow(request);
            var product = _mapper.Map<Product>(request);
            _context.Add(product);
            _context.SaveChanges();
        }
    }
}
