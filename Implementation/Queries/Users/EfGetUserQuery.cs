using Application.DataTransfer.UsersDto;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Users
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetUserQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 33;

        public string Name => "Show User using Ef";

        public UserSearchDto Execute(int search)
        {
            var user = _context.Users.Include(x => x.UserGroups).ThenInclude(x => x.Group).FirstOrDefault(x => x.Id == search);
            if (user == null) 
            {
                throw new EntityNotFoundException(search, typeof(User));
            }
            return _mapper.Map<UserSearchDto>(user);
        }
    }
}

