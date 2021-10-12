using Application.DataTransfer.UsersDto;
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

namespace Implementation.Queries.UseCaseLogs
{
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;
        public EfGetUseCaseLogsQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 38;

        public string Name => "Show use case logs using Ef";

        public PageResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();
            if(!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var criteria = search.Keyword.ToLower();
                query = query.Where(x => x.Actor.ToLower().Contains(criteria) ||
                                         x.Data.ToLower().Contains(criteria));
            }
            if (search.FromDate.HasValue)
            {
                query = query.Where(x => x.Date >= search.FromDate);
            }
            if (search.FromDate.HasValue)
            {
                query = query.Where(x => x.Date <= search.ToDate);
            }

            return query.Paged<UseCaseLogDto, UseCaseLog>(search, _mapper);
        }
    }
}
