using Application.Commands.Genders;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Genders
{
    public class EfDeleteGenderCommand : IDeleteGenderCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteGenderCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Delete gender using EF";

        public void Execute(int request)
        {
            var gender = _context.Genders.Include(x => x.Products).FirstOrDefault(x => x.Id == request);
            if (gender == null)
            {
                throw new EntityNotFoundException(request, typeof(Gender));
            }
            if (gender.Products.Any())
            {
                throw new ConflictException(request, typeof(Gender));
            }
            _context.Genders.Remove(gender);
            _context.SaveChanges();
        }
    }
}
