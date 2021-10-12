using Application.Commands.Seasons;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Seasons
{
    public class EfDeleteSeasonCommand : IDeleteSeasonCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteSeasonCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 22;

        public string Name => "Delete Season using Ef.";

        public void Execute(int request)
        {
            var season = _context.Seasons.Include(x => x.Products).FirstOrDefault(x => x.Id == request);
            if (season == null)
            {
                throw new EntityNotFoundException(request, typeof(Season));
            }
            if (season.Products.Any())
            {
                throw new ConflictException(request, typeof(Season));
            }
            _context.Seasons.Remove(season);
            _context.SaveChanges();
        }
    }
}
