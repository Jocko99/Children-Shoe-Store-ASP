using Application.Commands.Groups;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Groups
{
    public class EfDeleteGroupCommand : IDeleteGroupCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteGroupCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Delete Group using Ef";

        public void Execute(int request)
        {
            var group = _context.Groups.Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == request);
            if (group == null)
            {
                throw new EntityNotFoundException(request, typeof(Group));
            }
            if (group.UserUseCases.Any())
            {
                throw new ConflictException(request, typeof(Group));
            }
            _context.Groups.Remove(group);
            _context.SaveChanges();
        }
    }
}
