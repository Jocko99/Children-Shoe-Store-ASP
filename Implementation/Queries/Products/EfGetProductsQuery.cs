using Application.DataTransfer.ProductsDto;
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

namespace Implementation.Queries.Products
{
    public class EfGetProductsQuery : IGetProductsQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetProductsQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 405;

        public string Name => "Show products using Ef.";

        public PageResponse<ProductSearchDto> Execute(ProductSearch search)
        {
            var product = _context.Products.Include(x => x.Brand)
                                            .Include(x => x.Color)
                                            .Include(x => x.Season)
                                            .Include(x => x.Gender)
                                            .Include(x => x.Prices)
                                            .Include(x => x.Ratings)
                                            .Include(x => x.Comments)
                                            .Include(x => x.ProductSizes)
                                            .Include(x => x.Category)
                                            .AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                var criteria = search.Keyword.ToLower();
                product = product.Where(x => x.Brand.Name.ToLower().Contains(criteria) ||
                                             x.Description.ToLower().Contains(criteria) ||
                                             x.Category.Name.ToLower().Contains(criteria));
            }
            if (search.MinPrice.HasValue)
            {
                product = product.Where(x => x.Prices.Any(y => y.Value >= search.MinPrice));
            }
            if (search.MaxPrice.HasValue)
            {
                product = product.Where(x => x.Prices.Any(y => y.Value <= search.MaxPrice));
            }
            if (search.CategoryId.HasValue)
            {
                product = product.Where(x => x.CategoryId == search.CategoryId);
            }
            if (search.BrandId.HasValue)
            {
                product = product.Where(x => x.BrandId == search.BrandId);
            }
            if (search.ColorId.HasValue)
            {
                product = product.Where(x => x.ColorId == search.ColorId);
            }
            if (search.GenderId.HasValue)
            {
                product = product.Where(x => x.GenderId == search.GenderId);
            }
            if (search.SizeId.HasValue)
            {
                product = product.Where(x => x.ProductSizes.Any(y => y.SizeId == search.SizeId));
            }
            if (search.SeasonId.HasValue)
            {
                product = product.Where(x => x.SeasonId  == search.SeasonId);
            }

            return product.Paged<ProductSearchDto,Product>(search, _mapper);
        }
    }
}
