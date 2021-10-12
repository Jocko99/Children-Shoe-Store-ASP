using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain.Entites;
using EfDataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Groups
{
    public class EfGetGroupsQuery : IGetGroupQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetGroupsQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 37;

        public string Name => "Show Groups using Ef";

        public PageResponse<GroupDto> Execute(GroupSearch search)
        {
            var group = _context.Groups.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                group = group.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return group.Paged<GroupDto,Group>(search, _mapper);
        }
    }
}
