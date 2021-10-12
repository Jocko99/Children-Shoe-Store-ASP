using Application.DataTransfer.ProductsDto;
using EfDataAccess;
using FluentValidation;
using Implementation.Validators.Price;
using Implementation.Validators.ProductSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Product
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required parameter").DependentRules(() =>
            {
                RuleFor(x => x.CategoryId).Must(category => _context.Categories.Any(y => y.Id == category)).WithMessage("Category with an id of {PropertyValue} doesn't exists in database.");
            });
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Brand is required parameter").DependentRules(() =>
            {
                RuleFor(x => x.BrandId).Must(brand => _context.Brands.Any(y => y.Id == brand)).WithMessage("Brand with an id of {PropertyValue} doesn't exists in database.");
            });
            RuleFor(x => x.ColorId).NotEmpty().WithMessage("Color is required parameter").DependentRules(() =>
            {
                RuleFor(x => x.ColorId).Must(color => _context.Colors.Any(y => y.Id == color)).WithMessage("Color with an id of {PropertyValue} doesn't exist in database.");
            });
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender is required parameter").DependentRules(() =>
            {
                RuleFor(x => x.GenderId).Must(gender => _context.Genders.Any(y => y.Id == gender)).WithMessage("Gender with an id of {PropertyValue} doesn't exists in database.");
            });
            RuleFor(x => x.SeasonId).NotEmpty().WithMessage("Season is required parameter").DependentRules(() =>
            {
                RuleFor(x => x.SeasonId).Must(season => _context.Seasons.Any(y => y.Id == season)).WithMessage("Season with an id of {PropertyValue} doesn't exists in database.");
            });
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required").DependentRules(() =>
            {
                RuleFor(x => x.Image).Must(image => !_context.Products.Any(y => y.Image == image)).WithMessage("Image with a name {PropertyValue} already exists in database.");
            });
            RuleFor(x => x.ProductSizes).NotEmpty().WithMessage("Product size is requred.").DependentRules(() =>
            {
                RuleFor(x => x.ProductSizes).Must(ps =>
                {
                    var productSizesDistinct = ps.Select(x => x.SizeId).Distinct();
                    return productSizesDistinct.Count() == ps.Count();
                }).WithMessage("Duplicated sizes for one product isn't allowed.").DependentRules(() => 
                {
                    RuleForEach(x => x.ProductSizes).SetValidator(new ProductSizeValidator(_context));
                });
            });
            RuleFor(x => x.Prices).NotEmpty().WithMessage("Price is requred").DependentRules(() =>
            {
                RuleFor(x => x.Prices).Must(p => p.Count() == 1).WithMessage("You can add only one price").DependentRules(() =>
                {
                    RuleForEach(x => x.Prices).SetValidator(new PriceValidator());
                });
            });
        }
    }
}
