using Application.Commands.Categories;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Categories
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteCategoryCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 6;

        public string Name => "Delete Category using Ef";

        public void Execute(int request)
        {
            var category = _context.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == request);
            if (category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }
            if (category.Products.Any())
            {
                throw new ConflictException(request, typeof(Category));
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
