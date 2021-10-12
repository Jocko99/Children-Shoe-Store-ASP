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
    public class EfDeleteUserUseCaseCommand : IDeleteUserUseCaseCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteUserUseCaseCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 32;

        public string Name => "Delete User Use Case using Ef";

        public void Execute(int request)
        {
            var usecase = _context.UserUseCases.Find(request);
            if (usecase == null)
            {
                throw new EntityNotFoundException(request, typeof(UserUseCase));
            }
            _context.UserUseCases.Remove(usecase);
            _context.SaveChanges();
        }
    }
}
