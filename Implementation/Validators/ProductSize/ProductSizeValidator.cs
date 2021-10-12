using Application.DataTransfer.ProductsDto;
using EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.ProductSize
{
    public class ProductSizeValidator : AbstractValidator<ProductSizeDto>
    {
        public ProductSizeValidator(ShoeStoreContext _context)
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be above 0");
            RuleFor(x => x.SizeId).NotEmpty().WithMessage("Size is required.").DependentRules(() =>
            {
                RuleFor(x => x.SizeId).Must(size => _context.Sizes.Any(y => y.Id == size)).WithMessage("Size with an id of {PropertyValue} doesn't exist in database.");
            });
        }
    }
}
