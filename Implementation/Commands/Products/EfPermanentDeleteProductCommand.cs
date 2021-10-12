using Application.Commands.Products;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Products
{
    public class EfPermanentDeleteProductCommand : IDeleteProductCommand
    {
        private readonly ShoeStoreContext _context;

        public EfPermanentDeleteProductCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 19;

        public string Name => "Permanent delete product using Ef";

        public void Execute(int request)
        {
            var product = _context.Products.Include(x => x.ProductSizes).FirstOrDefault(x => x.Id == request);
            if (product == null)
            {
                throw new EntityNotFoundException(request, typeof(Product));
            }
            if (product.ProductSizes.Any())
            {
                throw new ConflictException(request, typeof(Season));
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
