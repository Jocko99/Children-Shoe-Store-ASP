using Application.Commands.Products;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Products
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteProductCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 18;

        public string Name => "Delete Product using Ef";

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);
            if (product == null)
            {
                throw new EntityNotFoundException(request, typeof(Product));
            }
            product.IsActive = false;
            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
