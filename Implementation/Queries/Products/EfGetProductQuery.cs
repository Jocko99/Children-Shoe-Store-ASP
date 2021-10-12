using Application.DataTransfer.ProductsDto;
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

namespace Implementation.Queries.Products
{
    public class EfGetProductQuery : IGetProductQuery
    {
        private readonly ShoeStoreContext _context;
        private readonly IMapper _mapper;

        public EfGetProductQuery(ShoeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 406;

        public string Name => "Show Product using Ef.";

        public ProductInfoDto Execute(int search)
        {
            var product = _context.Products.Include(x => x.Brand)
                                            .Include(x => x.Color)
                                            .Include(x => x.Season)
                                            .Include(x => x.Gender)
                                            .Include(x => x.Prices)
                                            .Include(x => x.Ratings)
                                            .Include(x => x.Category)
                                            .Include(x => x.Comments)
                                            .ThenInclude(x => x.User)
                                            .Include(x => x.ProductSizes)
                                            .ThenInclude(x => x.Size)
                                            .FirstOrDefault(x => x.Id == search);
            if (product == null)
            {
                throw new EntityNotFoundException(search, typeof(Product));
            }
            return _mapper.Map<ProductInfoDto>(product);
            //return new ProductInfoDto
            //{
            //    Name = product.Brand.Name,
            //    Color = product.Color.Name,
            //    Description = product.Description,
            //    //Comments = x.Comments.Select(y => new CommentDto
            //    //{
            //    //    ProductId = x.Id,
            //    //    Text = y.Text
            //    //}).ToList(),
            //    Gender = product.Gender.Name,
            //    Image = product.Image,
            //    //Price = product.Prices.Select(y => new PriceDto
            //    //{
            //    //    ProductId = product.Id,
            //    //    Value = y.Value
            //    //}).ToList(),
            //    Season = product.Season.Name,
            //    Size = product.ProductSizes.Select(x => x.Size.Value).ToArray()
            //};
        }
    }
}

