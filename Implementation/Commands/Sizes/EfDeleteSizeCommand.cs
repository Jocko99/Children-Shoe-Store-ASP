using Application.Commands.Sizes;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Sizes
{
    public class EfDeleteSizeCommand : IDeleteSizeCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteSizeCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 25;

        public string Name => "Delete Size using Ef";

        public void Execute(int request)
        {
            var size = _context.Sizes.Include(x => x.ProductSizes).FirstOrDefault(x => x.Id == request);
            if (size == null)
            {
                throw new EntityNotFoundException(request, typeof(Size));
            }
            if (size.ProductSizes.Any())
            {
                throw new ConflictException(request, typeof(Size));
            }
            _context.Sizes.Remove(size);
            _context.SaveChanges();
        }
    }
}
