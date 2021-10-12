using Application.Commands.Products;
using Application.DataTransfer.ProductsDto;
using Application.Exceptions;
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
    public class EfUpdateProductCommand : IUpdateProductCommand
    {
        private readonly ShoeStoreContext _context;
        private readonly ProductValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateProductCommand(ShoeStoreContext context, ProductValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 17;

        public string Name => "Update Product using Ef";

        public void Execute(ProductDto request)
        {
            var product = _context.Products.Find(request.Id);
            if (product == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Product));
            }

            _validator.ValidateAndThrow(request);
            _mapper.Map(request, product);
            _context.SaveChanges();
        }
    }
}
