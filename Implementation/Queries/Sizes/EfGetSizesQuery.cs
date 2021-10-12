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

namespace Implementation.Queries.Sizes
{
    public class EfGetSizesQuery : IGetSizeQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetSizesQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 408;

        public string Name => "Show Sizes using Ef";

        public PageResponse<SizeDto> Execute(SizeSearch search)
        {
            var size = _context.Sizes.AsQueryable();
            if (search.Value.HasValue)
            {
                size = size.Where(x => x.Value == search.Value);
            }
            if (search.MinValue.HasValue)
            {
                size = size.Where(x => x.Value >= search.MinValue);
            }
            if (search.MaxValue.HasValue)
            {
                size = size.Where(x => x.Value <= search.MaxValue);
            }
            return size.Paged<SizeDto,Size>(search, _mapper);
        }
    }
}
