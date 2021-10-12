using Application.Commands.Colors;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Colors
{
    public class EfDeleteColorCommand : IDeleteColorCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteColorCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name => "Delete Color using Ef";

        public void Execute(int request)
        {
            var color = _context.Colors.Include(x => x.Products).FirstOrDefault(x => x.Id == request);
            if (color == null)
            {
                throw new EntityNotFoundException(request, typeof(Color));
            }
            if (color.Products.Any())
            {
                throw new ConflictException(request, typeof(Color));
            }
            _context.Colors.Remove(color);
            _context.SaveChanges();
        }
    }
}
