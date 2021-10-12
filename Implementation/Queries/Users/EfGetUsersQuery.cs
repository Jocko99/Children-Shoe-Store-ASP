using Application.DataTransfer.UsersDto;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Users
{
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetUsersQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 34;

        public string Name => "Show Users using Ef";

        public PageResponse<UserDto> Execute(UserSearch search)
        {
            var user = _context.Users.Include(x => x.UserGroups).ThenInclude(x => x.Group).AsQueryable();
            if(!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var criteria = search.Keyword.ToLower();
                user = user.Where(x => x.FirstName.ToLower().Contains(criteria) ||
                                        x.LastName.ToLower().Contains(criteria) ||
                                        x.Email.ToLower().Contains(criteria) ||
                                        x.PhoneNumber.ToLower().Contains(criteria));
            }
            if (search.DateFrom.HasValue)
            {
                user = user.Where(x => x.CreatedAt >= search.DateFrom);
            }
            if (search.DateFrom.HasValue)
            {
                user = user.Where(x => x.CreatedAt <= search.DateTo);
            }
            return user.Paged<UserDto, User>(search, _mapper);
        }
    }
}
