using Application.Commands.Brands;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Brands
{
    public class EfDeleteBrandCommand : IDeleteBrandCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteBrandCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Delete brand using Ef";

        public void Execute(int request)
        {
            var brand = _context.Brands.Include(x => x.Products).FirstOrDefault(x => x.Id == request);
            if(brand == null)
            {
                throw new EntityNotFoundException(request, typeof(Brand));
            }
            if (brand.Products.Any())
            {
                throw new ConflictException(request, typeof(Brand));
            }
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}
