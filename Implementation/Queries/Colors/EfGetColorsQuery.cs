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

namespace Implementation.Queries.Colors
{
    public class EfGetColorsQuery : IGetColorQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetColorsQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 402;

        public string Name => "Show Colors using Ef";

        public PageResponse<ColorDto> Execute(ColorSearch search)
        {
            var color = _context.Colors.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                color = color.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return color.Paged<ColorDto, Color>(search, _mapper);
        }
    }
}
