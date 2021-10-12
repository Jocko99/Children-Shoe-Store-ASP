using Application.DataTransfer;
using Application.Queries;
using Application.Queries.Brands;
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

namespace Implementation.Queries.Brands
{
    public class EfGetBrandsQuery : IGetBrandsQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetBrandsQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 400;

        public string Name => "Show brands using Ef";

        public PageResponse<BrandDto> Execute(BrandSearch search)
        {
            var brands = _context.Brands.AsQueryable();
            if(!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                brands = brands.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return brands.Paged<BrandDto, Brand>(search, _mapper);
        }
    }
}
