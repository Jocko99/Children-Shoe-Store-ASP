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

namespace Implementation.Queries.Categories
{
    public class EfGetCategoriesQuery : IGetCategoryQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetCategoriesQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 401;

        public string Name => "Show Categories using Ef";

        public PageResponse<CategoryDto> Execute(CategorySearch search)
        {
            var category = _context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) && !string.IsNullOrWhiteSpace(search.Name))
            {
                category = category.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return category.Paged<CategoryDto, Category>(search, _mapper);
        }
    }
}
