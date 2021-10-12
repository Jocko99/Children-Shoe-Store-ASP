using Application.DataTransfer;
using Application.DataTransfer.ProductsDto;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ForMember(product => product.IsActive, opt => opt.MapFrom(o => o.IsActive))
                .ForMember(product => product.ProductSizes, opt => opt.MapFrom(o => o.ProductSizes.Select(x => new ProductSize
            {
                ProductId = x.ProductId,
                SizeId = x.SizeId,
                Quantity = x.Quantity
            }))).ForMember(product => product.Prices, opt => opt.MapFrom(o => o.Prices.Select(x => new Price {
                ProductId = x.ProductId,
                Value = x.Value
            })));

            CreateMap<Product, ProductSearchDto>().ForMember(dto => dto.Name, opt => opt.MapFrom(product => product.Brand.Name + " " + product.Category.Name + "," + product.Gender.Name))
                                                 .ForMember(dto => dto.Image, opt => opt.MapFrom(product => product.Image))
                                                 .ForMember(dto => dto.Price, opt => opt.MapFrom(product => product.Prices.Select(x => new PriceSearchDto
                                                 {
                                                     Value = x.Value,
                                                     Date = x.CreatedAt
                                                 }).OrderByDescending(x => x.Date).Take(1).ToList()));

            CreateMap<Product, ProductInfoDto>().ForMember(dto => dto.Name, opt => opt.MapFrom(product => product.Brand.Name + " " + product.Category.Name + "," + product.Gender.Name))
                                                .ForMember(dto => dto.Gender, opt => opt.MapFrom(product => product.Gender.Name))
                                                .ForMember(dto => dto.Color, opt => opt.MapFrom(product => product.Color.Name))
                                                .ForMember(dto => dto.Season, opt => opt.MapFrom(product => product.Season.Name))
                                                .ForMember(dto => dto.Description, opt => opt.MapFrom(product => product.Description))
                                                .ForMember(dto => dto.Image, opt => opt.MapFrom(product => product.Image))
                                                .ForMember(dto => dto.Ratings, opt => opt.MapFrom(product => product.Ratings.Select(x => new RatingDto { ProductId = product.Id, Value = x.Value })))
                                                .ForMember(dto => dto.Price, opt => opt.MapFrom(product => product.Prices.Select(x => new PriceSearchDto
                                                {
                                                    Value = x.Value,
                                                    Date = x.CreatedAt
                                                }).OrderByDescending(x => x.Date).Take(1).ToList()))
                                                .ForMember(dto => dto.Comments, opt => opt.MapFrom(product => product.Comments.Select(x => new CommentDto
                                                {
                                                    ProductId = x.ProductId,
                                                    User = x.User.FirstName,
                                                    Text = x.Text
                                                }).ToList()))
                                                .ForMember(dto => dto.Size, opt => opt.MapFrom(product => product.ProductSizes.Select(x => new SizeDto { 
                                                    Id = x.Id,
                                                    Value = x.Size.Value
                                                }).ToList()))
                                                ;
        }



        

        #region Product withoud Automapper
        //var product = new Product
        //{
        //    BrandId = request.BrandId,
        //    CategoryId = request.CategoryId,
        //    ColorId = request.ColorId,
        //    GenderId = request.GenderId,
        //    SeasonId = request.SeasonId,
        //    Description = request.Description,
        //    Image = request.Image,
        //    ProductSizes = request.ProductSizes.Select(x => new ProductSize
        //    {
        //        ProductId = request.Id,
        //        SizeId = x.SizeId,
        //        Quantity = x.Quantity
        //    }).ToList(),
        //    Prices = request.Prices.Select(x => new Price
        //    {
        //        ProductId = request.Id,
        //        Value = x.Value
        //    }).ToList()
        //};
        #endregion
    }
}
