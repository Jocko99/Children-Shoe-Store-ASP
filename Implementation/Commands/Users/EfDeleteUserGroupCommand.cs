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
    public class EfDeleteUserGroupCommand : IDeleteUserGroupCommand
    {
        private readonly ShoeStoreContext _context;

        public EfDeleteUserGroupCommand(ShoeStoreContext context)
        {
            _context = context;
        }

        public int Id => 29;

        public string Name => "Delete User from Group using Ef.";

        public void Execute(int first, int second)
        {
            var find = _context.UserGroups.FirstOrDefault(x => x.UserId == first && x.GroupId == second);
            if(find == null)
            {
                throw new EntityNotFoundException(first, second, typeof(User), typeof(Group));
            }
            _context.UserGroups.Remove(find);
            _context.SaveChanges();
        }
    }
}
