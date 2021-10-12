using Application.Commands.Users;
using Application.Exceptions;
using Domain.Entites;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteUserCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 27;

        public string Name => "Delete user using Ef.";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);
            if(user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }
            user.IsActive = false;
            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
